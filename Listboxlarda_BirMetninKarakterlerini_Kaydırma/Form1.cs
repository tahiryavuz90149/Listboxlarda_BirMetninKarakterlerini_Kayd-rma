using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Listboxlarda_BirMetninKarakterlerini_Kaydırma
{
    public partial class Form1 : Form
    {
        public int index = 0 ;
        public string metin= "";
        int kapasite1;
        int kapasite2;
        int kapasite3;


        public Form1()
        {
            InitializeComponent();
        }

        private void buttonBasla_Click(object sender, EventArgs e)
        {
            metin = textBox1.Text;
            kapasite1 = (int)numericUpDown1.Value;
            kapasite2 = (int)numericUpDown2.Value;
            kapasite3 = (int)numericUpDown3.Value;
            timer1.Start();
            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (metin.Length==index)
            {
                timer1.Stop();
                return;

            }
            if (index == metin.Length) // metin boyutunun index değerine eşit olup olmadığı kontrol ediliyor.
            {
                timer1.Stop();
                return;

            }
            if (radioButtonSoldanSaga.Checked == true)    
            {
                listBox1.Items.Insert(0, metin[index++]);
                if (listBox1.Items.Count > kapasite1) // listbox1 içindeki ifadelerin sayısı kapasite1 den büyükmü?
                {
                    listBox2.Items.Insert(0, listBox1.Items[kapasite1]); // listbox1 içindeki son değeri listbox2'nin 0. indexine ekle
                    listBox1.Items.RemoveAt(kapasite1);
                    if (listBox2.Items.Count > kapasite2)
                    {
                        listBox3.Items.Insert(0, listBox2.Items[kapasite2]); // listbox2 içindeki son değeri listbox3'nin 0. indexine ekle
                        listBox2.Items.RemoveAt(kapasite2);
                        if (listBox3.Items.Count == kapasite3)
                        {
                            timer1.Stop();
                            MessageBox.Show("kapasite doldu.");
                        }
                    }
                }

            }
            else // soldan sağa değilse yani sağdan sola ise
            {
                listBox3.Items.Insert(0, metin[index++]);
                if (listBox3.Items.Count > kapasite3)
                {
                    listBox2.Items.Insert(0, listBox3.Items[kapasite3]);
                    listBox3.Items.RemoveAt(kapasite3);
                    if (listBox2.Items.Count > kapasite2)
                    {
                        listBox1.Items.Insert(0, listBox2.Items[kapasite2]);
                        listBox2.Items.RemoveAt(kapasite2);
                        if (listBox1.Items.Count == kapasite1)
                        {
                            timer1.Stop();
                            MessageBox.Show("kapasite doldu.");
                        }
                    }
                }
            }
            textBox1.Text = metin.Substring(index); // metni index numarasından itibaren geri döndür 
                                                        // örneğin metinimiz "yavuz" olsun index = 2 ise bize geri dönecek olan metin "uz" dur. 

        }

        private void buttonSıfırla_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();


            // resetlenince gelmesini istediğimiz değerleri belirtiyoruz.
            numericUpDown1.Value = 3;
            numericUpDown2.Value = 4;
            numericUpDown3.Value = 5;

            textBox1.Text = "";

            radioButtonSoldanSaga.Checked = true;
        }

       
    }
}

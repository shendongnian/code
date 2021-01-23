    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            ListView.SelectedListViewItemCollection items1;
            List<int> items2;
            public Form1()
            {
                InitializeComponent();
                items2 = new List<int>();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                for (int i = 0; i < 10; i++)
                {
                    listView1.Items.Add(i.ToString());
                }
            }
            private void button1_Click(object sender, EventArgs e)
            {
                items1 = listView1.SelectedItems;
                foreach (var item in listView1.SelectedItems)
                {
                    ListViewItem lvItem =(ListViewItem)item; 
                    items2.Add(int.Parse(lvItem.Text));
                }
            }
            private void button2_Click(object sender, EventArgs e)
            {
            }
        }
    }

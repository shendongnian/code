    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace DGMultiLine
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                int max = 12; //min Column Width in Char
                //do this for all rows of column for max Line Size in values
    
                string str = "Hello\r\nI am mojtaba\r\ni like programming very very \r\nrun this code and  pay attention to result\r\n Datagrid Must show this Line Good are you see whole of this Thats Finished!";
                string[] ss = str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
    
                //find max Line Size To Now
                for (int i = 0; i < ss.Length; i++)
                    if (ss[i] != null && ss[i] != "")
                        if (ss[i].Length > max)
                            max = ss[i].Length;
                //Set target Column Width
                dataGridView1.Columns[0].Width = max*5;//for adequate value you must refer to screen resolution
                //filling datagrigView for all values
                dataGridView1.Rows[0].Cells[0].Value = str;
            }
    
        }
    }

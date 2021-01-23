    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace cities
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
    
          
        
                StringBuilder message = new StringBuilder();
               
    
                foreach (object selectedItem in listBox1.SelectedItems)
                {
                   message.Append(selectedItem.ToString() + Environment.NewLine);
                }
                MessageBox.Show("Your Selected Cities :\n" + message.ToString() + "\n");
    
                Form2 childForm = new Form2();
                childForm.Controls["richTextBox1"].Text = message.ToString();
                childForm.Show();
            }
    
            private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
            }
    
        }
    }

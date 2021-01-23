    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace childform
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Form2 tempDialog = new Form2(this);
                tempDialog.ShowDialog();
            }
    
            public void msgme()
            {
                MessageBox.Show("Parent Function Called");
            }
    
        }
    }

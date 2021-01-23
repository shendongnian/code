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
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {   //call the form
                MyChildForm cForm = new MyChildForm();
                if (cForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {   //get the selected row object
                    DataGridViewRow dgvRow = cForm.selectedRow;
                }
            }
        }
    }

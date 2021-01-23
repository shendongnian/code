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
        public partial class MyChildForm : Form
        {
            public DataGridViewRow selectedRow;
    
            public MyChildForm()
            {
                InitializeComponent();
            }
    
            private void MyChildForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                //Forms closing so lets get the results
                selectedRow = dataGridView1.SelectedRows[0];
            }
    
    
    
        }
    }

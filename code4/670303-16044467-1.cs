    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    
    namespace childform
    {
        public partial class Form2 : Form
        {
            private Form1 m_parent;
    
            public Form2(Form1 frm1)
            {
                InitializeComponent();
                m_parent = frm1;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                m_parent.msgme();
            }
        }
    }

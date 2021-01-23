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
            DerivedUserControl dv = new DerivedUserControl();
            public Form1()
            {
                InitializeComponent();
           
                this.Controls.Add(dv);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                if (dv.IsTitlePanelVisible)
                    dv.IsTitlePanelVisible = false;
                else
                    dv.IsTitlePanelVisible = true;
            }
        }
    }

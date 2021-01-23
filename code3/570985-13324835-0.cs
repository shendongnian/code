    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Windows.Forms.Integration;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            ElementHost host;
            WpfControlLibrary1.UserControl1 uc;
            public Form1()
            {
                InitializeComponent();
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                host = new ElementHost();
                host.Dock = DockStyle.Top;
                uc = new WpfControlLibrary1.UserControl1();
                host.Child = uc;
                this.Controls.Add(host);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                uc.SetChildLocation =  new  System.Windows.Point(uc.SetChildLocation.X + 25.5, uc.SetChildLocation.Y + 10.2);
            }
            private void button2_Click(object sender, EventArgs e)
            {
                uc.SetChildSize = new System.Windows.Size(uc.SetChildSize.Width + .25, uc.SetChildSize.Height + .25);
            }
        }
    }

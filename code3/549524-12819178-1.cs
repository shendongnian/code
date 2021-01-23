    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using InstallToolboxControls;
    namespace WindowsFormsApplication12
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                InstallToolboxControls.Program prg = new InstallToolboxControls.Program();
                InstallToolboxControls.Program.Toolbox("Install");
            }
        }
    }

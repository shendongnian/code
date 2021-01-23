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
            private Panel panel1;
    
            public Form1()
            {
                InitializeComponent();
            }
            private void InitializeComponent()
            {
                this.panel1 = new System.Windows.Forms.Panel();
                this.SuspendLayout();
                // 
                // panel1
                // 
                this.panel1.Location = new System.Drawing.Point(101, 62);
                this.panel1.Name = "panel1";
                this.panel1.Size = new System.Drawing.Size(200, 100);
                this.panel1.TabIndex = 0;
                // 
                // Form1
                // 
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Controls.Add(this.panel1);
                this.Name = "Form1";
                this.ResumeLayout(false);
            }
        }
    }

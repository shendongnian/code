    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace ICAMReports
    {
        public partial class Form3 : Form
        {
            public string source;
            public Form3(string path)
            {
                source = path;
                InitializeComponent();
            }
            private void Form3_Load(object sender, EventArgs e)
            {
                this.crystalReportViewer1.ReportSource = source;
            }
        }
    }

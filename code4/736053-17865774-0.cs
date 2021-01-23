    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using Microsoft.Office.Interop.Excel;
    
    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                string path = @"path to first Excel file";
                string path2 = @"path to second Excel file";
    
                Microsoft.Office.Interop.Excel.Application oXL = new Microsoft.Office.Interop.Excel.Application();
                Workbook oWB = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Worksheet oSheet = (Worksheet)oWB.ActiveSheet;
    
                Microsoft.Office.Interop.Excel.Application oXL2 = new Microsoft.Office.Interop.Excel.Application();
                Workbook oWB2 = oXL2.Workbooks.Open(path2, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Worksheet oSheet2 = (Worksheet)oWB2.ActiveSheet;
    
                oXL.Visible = true;
                oXL2.Visible = true;
    
                oXL = null;
                oXL2 = null;
            }
        }
    }

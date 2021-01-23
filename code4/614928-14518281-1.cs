    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    namespace WindowsFormsApplication6
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                object xlApp;
                object xlWbCol;
                object xlWb;
                object xlSheet;
                object xlRange;
                object xlWsCol;
                //~~> create new Excel instance
                Type tp;
                tp = Type.GetTypeFromProgID("Excel.Application");
                xlApp = Activator.CreateInstance(tp);
                object[] parameter = new object[1];
                parameter[0] = true;
                xlApp.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, xlApp, parameter);
                xlApp.GetType().InvokeMember("UserControl", BindingFlags.SetProperty, null, xlApp, parameter);
                //~~> Get the xlWb collection
                xlWbCol = xlApp.GetType().InvokeMember("Workbooks", BindingFlags.GetProperty, null, xlApp, null);
                //~~> Create a new xlWb
                xlWb = xlWbCol.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, xlWbCol, null);
                //~~> Get the worksheet collection
                xlWsCol = xlWb.GetType().InvokeMember("WorkSheets", BindingFlags.GetProperty, null, xlApp, null);
                //~~> Create a new workxlSheet
                xlSheet = xlWb.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, xlWsCol, null);
                //~~> Rename the workxlSheet to your SO Handle
                xlSheet.GetType().InvokeMember("Name", BindingFlags.SetProperty, null, xlSheet, new object[] { "confusedMind" });
                //~~> Assign cell D10 to xlRange object
                xlRange = xlSheet.GetType().InvokeMember("Range", BindingFlags.GetProperty, null, xlSheet, new object[] { "D10" });
                //~~> Write to cell D10
                xlRange.GetType().InvokeMember("Value", BindingFlags.SetProperty, null, xlRange, new object[] { "Blah Blah" });
                //~~> Release the object
                System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
            }
        }
    }

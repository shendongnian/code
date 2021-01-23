    using System;
    using System.Windows.Forms;
    using CrystalDecisions.CrystalReports.Engine;
    using CrystalDecisions.Shared;
    using System.Data;
    
    namespace WindowsApplication1
    {
        public partial class Form1 : Form
        {
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataSet1 ds = new DataSet1();
                DataTable t = ds.Tables.Add("Items");
                t.Columns.Add("id", Type.GetType("System.Int32"));
                t.Columns.Add("Item", Type.GetType("System.String"));
    
                DataRow r ;
                int i = 0;
                for (i = 0; i <= 9; i++)
                {
                    r = t.NewRow();
                    r["id"] = i;
                    r["Item"] = "Item" + i;
                    t.Rows.Add(r);
                }
    
                CrystalReport1 objRpt = new CrystalReport1();
                objRpt.SetDataSource(ds.Tables[1]);
                crystalReportViewer1.ReportSource = objRpt;
                crystalReportViewer1.Refresh(); 
            }
        }
    }

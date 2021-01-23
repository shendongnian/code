    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Configuration;
    
    
    using System.Data.SqlClient;
    using Microsoft.Reporting.WinForms;
    
    namespace RDLC
    {
        public partial class RD : Form
        {
            public RD()
            {
                InitializeComponent();
            }
    
            private void RD_Load(object sender, EventArgs e)
            {
                DataTable dt = new DataTable();
                dt = GetData("select * from tbl_Admission_Form");
                ReportDataSource datasource = new ReportDataSource("DataSet1", dt);
                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.ProcessingMode = ProcessingMode.Local;
                reportViewer1.LocalReport.ReportEmbeddedResource = "RDLC.Report1.rdlc";
                reportViewer1.LocalReport.DataSources.Add(datasource);
                //this.reportViewer1.RefreshReport();
                this.reportViewer1.RefreshReport();
            }
            private DataTable GetData(string query)
            {
                string conString = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;
                SqlConnection con = new SqlConnection(conString);
                con.Open();
                SqlCommand cmd = new SqlCommand(query);
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable ds = new DataTable();
                sda.Fill(ds);
                return ds;
            }
        }
    }

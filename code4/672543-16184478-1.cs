      using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.UI;
        using System.Web.UI.WebControls;
        using System.Reflection;
        using CrystalDecisions.CrystalReports.Engine;
        using CrystalDecisions.Shared;
        using CrystalDecisions.Reporting;
        using CrystalDecisions;
        using System.Data.SqlClient;
        using System.Data;
        using BusinessAccessLevel;
        using BusinessAccessLevel.Masters;
        
        namespace TexERP.ReportCrystal.Sales
        {
            public partial class CityReportCry : System.Web.UI.Page
            {
                ReportDocument doc;
            }
        
         protected void btnShowReport_Click(object sender, EventArgs e)
                {
                    OldLoadReport();            
                }
        
              private void OldLoadReport()
                {
                    doc = new ReportDocument();
                    doc.Load(Server.MapPath("MR.rpt"));
               doc.SetDatabaseLogon("sa", "Admin123", "vivek", "PURCHASE", false);
                CrystalReportViewer1.ReportSource = doc;
                }
        
                protected void CrystalReportViewer1_Init(object sender, EventArgs e)
                {
                    OldLoadReport();
                }
            }
        }

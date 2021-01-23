            ReportDocument rpt = new ReportDocument();
            rpt.Load(@"C:\LT0001_COBDEN.rpt");
            foreach (Area a in rpt.ReportDefinition.Areas)
            {
                string s = a.Name;
            }
            foreach (Section c in rpt.ReportDefinition.Sections)
            {
                string s = c.Name;
            }
            ObjectFormat of = rpt.ReportDefinition.Sections["GroupHeaderSection9"].ReportObjects["Text21"].ObjectFormat;
            TextObject to = (TextObject)rpt.ReportDefinition.Sections["GroupHeaderSection9"].ReportObjects["Text21"];
            to.Color = Color.Red;
            crystalReportViewer1.ReportSource = rpt;
            crystalReportViewer1.Refresh();

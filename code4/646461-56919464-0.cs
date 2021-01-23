        private void frmPrint_Load(object sender, EventArgs e)
        {
            CreateReport1();
            System.Drawing.Printing.PageSettings ps = new 
                   System.Drawing.Printing.PageSettings();
            ps.Margins.Top = CentimeterToPixel(0.9);
            ps.Margins.Left = CentimeterToPixel(0.9);
            ps.Margins.Right = CentimeterToPixel(0.9);
            ps.Margins.Bottom = CentimeterToPixel(0.9);
            ps.Landscape = false;
            ps.PaperSize =new PaperSize ("A4", 827, 1169);
            ps.PaperSize.RawKind = (Int32)(System.Drawing.Printing.PaperKind.A4);
            //psize.RawKind = (int)PaperKind.A4;
            //ps.PaperSize = psize;
            reportViewer1.SetPageSettings(ps);
            this.reportViewer1.RefreshReport();
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            WindowState = FormWindowState.Maximized;
        }
        private int CentimeterToPixel(double Centimeter)
        {
            int  pixel = -1;
            using (Graphics g = this.CreateGraphics())
            {
                pixel =Convert.ToInt32 ( Centimeter * (g.DpiY / 2.54));
            }
            return pixel;
        }
        private void CreateReport1()
        {
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.ProcessingMode = 
                         Microsoft.Reporting.WinForms.ProcessingMode.Local;
            reportViewer1.LocalReport.ReportEmbeddedResource = 
                            "yourProjectName.Report1.rdlc";
            ReportDataSource RDS = new ReportDataSource();
            RDS.Name = "DataSet1";
            RDS.Value = yourPublicList1;
            reportViewer1.LocalReport.DataSources.Add(RDS);
            ReportDataSource RDS2 = new ReportDataSource();
            RDS2.Name = "DataSet2";
            RDS2.Value = yourPublicList2;
            reportViewer1.LocalReport.DataSources.Add(RDS2);
        }

    DataTable dt = new DataTable();
            DataColumn column = new DataColumn("chart");
            column.DataType = System.Type.GetType("System.Byte[]");
            dt.Columns.Add(column);
            DataRow dr = dt.NewRow();
            //Saving the Image of Graph into memory stream
            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            Chart1.SaveImage(ms, ChartImageFormat.Png);
            byte[] ByteImage = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(ByteImage, 0, (int)ms.Length);
            
            dr["chart"] = ByteImage;
            string s = dr[0].ToString();
            dt.Rows.Add(dr);
            
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.ReportPath = "Report1.rdlc";
            
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1",dt));
            ReportViewer1.Visible = true;
            ReportViewer1.LocalReport.Refresh();

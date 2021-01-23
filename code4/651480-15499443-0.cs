       protected void btnExcel_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Phone");
            dt.Columns.Add("Name");
            DataRow Sample = dt.NewRow();
            Sample["Phone"] = 125316245612456124;
            Sample["Name"] = "Pandian";
            dt.Rows.Add(Sample);
            GetExcel(dt);            
        }
        public void GetExcel(DataTable dt)
        {
            string fileName = "File" + DateTime.Now.ToString("MMddyyyy_HHmmss") + ".xls";
            Response.AddHeader("content-disposition", "attachment;filename=" + fileName);
            Response.ContentType = "application/vnd.ms-excel";
            StringWriter stringWriter = new StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWriter);
            DataGrid dataExportExcel = new DataGrid();
            dataExportExcel.DataSource = dt;
            dataExportExcel.DataBind();
            dataExportExcel.RenderControl(htmlWrite);
            System.Text.StringBuilder sbResponseString = new System.Text.StringBuilder();
            sbResponseString.Append("<html xmlns:v=\"urn:schemas-microsoft-com:vml\" xmlns:o=\"urn:schemas-microsoft-com:office:office\" xmlns:x=\"urn:schemas-microsoft-com:office:xlExcel8\" xmlns=\"http://www.w3.org/TR/REC-html40\"> <head><style> td { mso-number-format:'0'; } </style></head> <body>");
            sbResponseString.Append(stringWriter + "</body></html>");
            Response.Write(sbResponseString.ToString());
            Response.End();
        }

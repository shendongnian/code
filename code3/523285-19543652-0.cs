    public void ExportToExcel(DataSet dataSet, string ExcelFilePath)
    {
         if (dataSet != null && dataSet.Tables.Count > 0)
         {
                string exportData = "";
                StringWriter stringWrite = new StringWriter();
                HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
                DataGrid dg = new DataGrid();
                this.dataTable = dataSet.Tables[0];
                dg.DataSource = this.dataTable;
                dg.DataBind();
                dg.RenderControl(htmlWrite);
                dg.Dispose();
                exportData = stringWrite.ToString();
                XTP.Framework.Interface.FileSystem.Save(exportData, ExcelFilePath);
         }
    }

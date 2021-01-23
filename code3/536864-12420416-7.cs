    protected void UploadButton_Click(Object sender, EventArgs e)
    {
        if (FileUpload1.HasFile && Path.GetExtension(FileUpload1.FileName) == ".xlsx")
        {
            using (var excel = new ExcelPackage(FileUpload1.PostedFile.InputStream))
            {
                var tbl = new DataTable();
                var ws = excel.Workbook.Worksheets.First();
                var hasHeader = true;  // adjust accordingly
                // add DataColumns to DataTable
                foreach (var firstRowCell in ws.Cells[1, 1, 1, ws.Dimension.End.Column])
                    tbl.Columns.Add(hasHeader ? firstRowCell.Text
                        : String.Format("Column {0}", firstRowCell.Start.Column));
                // add DataRows to DataTable
                int startRow = hasHeader ? 2 : 1;
                for (int rowNum = startRow; rowNum <= ws.Dimension.End.Row; rowNum++)
                {
                    var wsRow = ws.Cells[rowNum, 1, rowNum, ws.Dimension.End.Column];
                    DataRow row = tbl.NewRow();
                    foreach (var cell in wsRow)
                        row[cell.Start.Column - 1] = cell.Text;
                    tbl.Rows.Add(row);
                }
                var msg = String.Format("DataTable successfully created from excel-file. Colum-count:{0} Row-count:{1}",
                                        tbl.Columns.Count, tbl.Rows.Count);
                UploadStatusLabel.Text = msg;
            }
        }
        else 
        {
            UploadStatusLabel.Text = "You did not specify a file to upload.";
        }
    }

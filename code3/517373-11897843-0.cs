    protected void BtnTest_Click(object sender, EventArgs e)
    {
        FileInfo newFile = new FileInfo("C:\\Users\\Scott.Atkinson\\Desktop\\Book.xls");
        
        ExcelPackage pck = new ExcelPackage(newFile);
        //Add the Content sheet
        var ws = pck.Workbook.Worksheets.Add("Content");
        ws.View.ShowGridLines = false;
        ws.Column(4).OutlineLevel = 1;
        ws.Column(4).Collapsed = true;
        ws.Column(5).OutlineLevel = 1;
        ws.Column(5).Collapsed = true;
        ws.OutLineSummaryRight = true;
        //Headers
        ws.Cells["B1"].Value = "Name";
        ws.Cells["C1"].Value = "Size";
        ws.Cells["D1"].Value = "Created";
        ws.Cells["E1"].Value = "Last modified";
        ws.Cells["B1:E1"].Style.Font.Bold = true;
        pck.Save();
        System.Diagnostics.Process.Start("C:\\Users\\Scott.Atkinson\\Desktop\\Book.xls");
    }

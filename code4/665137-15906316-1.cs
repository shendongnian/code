    protected void Button1_Click(object sender, EventArgs e)
    {       
        if (FileUpload1.HasFile)
            try
            {
                var excelApp = new Application();
                excelApp.Workbooks.Open("C:\\myFile.xls", Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing,
                                                       Type.Missing, Type.Missing);
                var ws = excelApp.Worksheets;
                var worksheet = (Worksheet)ws.get_Item("Sheet1");
                Range range = worksheet.UsedRange;
                object[,] values = (object[,])range.Value2;
                for (int row = 1; row <= values.GetUpperBound(0); row++)
                {
                    string phone = Convert.ToString(values[row, 2]);
                    if (!phone.StartsWith("0"))
                    {
                        phone = "0" + phone;
                    }
                    range.Cells.set_Item(row, 2, phone);
                }
                excelApp.Save("C:\\Leads.xls");
                excelApp.Quit();
           }
            catch (Exception ex)
            {//}
        else
        {//}
    }

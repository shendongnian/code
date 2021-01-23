            // Creating the Excel file with Gembox
            ExcelFile ef = new ExcelFile();
            foreach (DataTable dt1 in ds.Tables)
            {
                ExcelWorksheet ws = ef.Worksheets.Add(dt1.TableName);
                ws.InsertDataTable(dt1, "A1", true);
            }

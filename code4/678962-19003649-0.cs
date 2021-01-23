      public static void AppendRefRow(string path)
        { 
            using (var pck = new ExcelPackage(new FileInfo(path)))
            {
                var ws = pck.Workbook.Worksheets.FirstOrDefault();
                var refRowIndex = 9;
                var refColumnIndex = 1; 
				
                for (int index = Items.Length - 1; index >= 0; index--)
                {
                    ws.InsertRow(refRowIndex, 1, refRowIndex);
                    ws.Cells[refRowIndex, refColumnIndex + 0].Value = index + 1;
					//TODO: write here other rows...
                }
                pck.Save();
            } 

                ExcelPackage package = new ExcelPackage();
                var ws = package.Workbook.Worksheets.Add("Test Page");
                
                for (int a = 0; a < 5; a++)
                {
                    ws.Row(a * 5).Height = 39.00D;
                }
    
                for (int a = 0; a < 5; a++)
                {
                    var picture = ws.Drawings.AddPicture(a.ToString(), logo);
                    picture.SetPosition(a * 5, 0, 2, 0);
                }

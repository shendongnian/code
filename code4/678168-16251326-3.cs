                var sourcePath = "Report_Template.xlsx";
            var data = File.ReadAllBytes(sourcePath);
            var memoryStream = new MemoryStream();
            memoryStream.Write(data, 0, data.Length);
                var processSettings = new MarkupCompatibilityProcessSettings
                (
                MarkupCompatibilityProcessMode.ProcessAllParts,
                FileFormatVersions.Office2007
                );
            var openSettings = new OpenSettings()
            {
                MarkupCompatibilityProcessSettings = processSettings,
                AutoSave = true
            };
            using (var spreadSheet = SpreadsheetDocument.Open(memoryStream, true, openSettings))
            {
                var worksheet = GetWorksheet(spreadSheet);
                var worksheetPart = worksheet.WorksheetPart;
                const int lastRowIndex = 1;
                var sheetData = worksheetPart.Worksheet.GetFirstChild<SheetData>();
                var lastRow = sheetData.Elements<Row>().LastOrDefault(l => l.RowIndex == lastRowIndex);
                var reportItems=null;//Get your reoirting data...    
                if (lastRow != null)
                {
                    foreach (var newRow in (from reportItem in reportItems
                                            let newRowIndex = lastRow.RowIndex + 1
                                            select CreateContentRow((int)newRowIndex, new object[] 
                        {
                            newRowIndex-lastRow.RowIndex,
                            reportItem.Column1,
                            reportItem.Column2
                    {
                        sheetData.InsertAfter(newRow, lastRow);
                    }
                    worksheet.Save();
                }
            }

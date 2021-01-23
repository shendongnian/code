    string fileName = AppDomain.CurrentDomain.BaseDirectory + "/Content/Master-License-Export.xlsx";
                        var spreadsheetDocument = SpreadsheetDocument.Open(fileName, true);           
                        WorkbookPart wbp = spreadsheetDocument.WorkbookPart;
                       
                        UInt32 localSheetId = 0;    //LocalSheetIds are 0-indexed.
             
                        var definedName = new DefinedName
                        {
                            Name = "_xlnm.Print_Titles",
                            LocalSheetId = localSheetId,
                            Text = String.Format("\'{0}\'!${1}:${2}", "Master-License-Export", 1, 4)
                        };
             
                        if (wbp.Workbook.DefinedNames == null)
                        {
                            var definedNamesCol = new DefinedNames();
                            wbp.Workbook.Append(definedNamesCol);
                        }
             
                        wbp.Workbook.DefinedNames.Append(definedName);
             
                        wbp.Workbook.Save();
                        spreadsheetDocument.Close(); 

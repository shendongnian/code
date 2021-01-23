        //open word doc   
         using (var wDoc = WordprocessingDocument.Open(someDocFileInfo.FullName, true))          
        {
           //open embedded excel object with chart
           var stream = wDoc.MainDocumentPart.EmbeddedPackageParts.First().GetStream();
        
           using (var ssDoc = SpreadsheetDocument.Open(stream, true))
           {
               var wbPart = ssDoc.WorkbookPart;
               var sheet = wbPart.Workbook.Descendants<Sheet>().FirstOrDefault(i => i.Name == "Sheet1");
               if (sheet != null)
               {
                   var ws = (wbPart.GetPartById(sheet.Id) as WorksheetPart).Worksheet;
                  //change the data in the excel sheet
                  var cell = InsertCellInWorksheet("A", 2, ws);
                  cell.CellValue = new CellValue("42");
                  cell.DataType = new DocumentFormat.OpenXml.EnumValue<CellValues>(CellValues.Number);
                   ws.Save();
               }   
           }
        
           //now 'touch' the word doc to refresh the chart
           var settingPart = wDoc.MainDocumentPart.GetPartsOfType<DocumentSettingsPart>().First();
           var updateFields = new UpdateFieldsOnOpen();
           updateFields.Val = new OnOffValue(true);
           settingPart.Settings.PrependChild<UpdateFieldsOnOpen>(updateFields);
           settingPart.Settings.Save();
           }
        }

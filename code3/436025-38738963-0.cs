     var worksheet = wb.Worksheets.Add("Overzicht");
                //  Adding text
                worksheet.Cell("B2").Value = "Overzicht activiteit";
                 var rngMainTitle = worksheet.Range("B2:E3");
                 rngMainTitle.FirstCell().Style
                     .Font.SetBold()
                     .Fill.SetBackgroundColor(XLColor.CornflowerBlue)
                     .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                     .Alignment.SetVertical(XLAlignmentVerticalValues.Center);
                 //Merge title cells
                 rngMainTitle.FirstRow().Merge();
                worksheet.Column(2).Width = 31;
                worksheet.Column(3).Width = 18;
                worksheet.Column(4).Width = 18;
                worksheet.Column(5).Width = 18;
                worksheet.Row(2).Height = 25;

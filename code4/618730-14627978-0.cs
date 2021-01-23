        public CopyChartFromXlsx2Pptx(string SourceFile, string TargetFile, string targetppt)
        {
            ChartPart chartPart;
            ChartPart newChartPart;
            //SlidePart slidepartbkMark = null;
            string chartPartIdBookMark = null;
            File.Copy(TargetFile, targetppt, true);
            //Powerpoint document
            using (OpenXmlPkg.PresentationDocument pptPackage = OpenXmlPkg.PresentationDocument.Open(targetppt, true))
            {
                OpenXmlPkg.PresentationPart presentationPart = pptPackage.PresentationPart;
                var secondSlidePart = pptPackage.PresentationPart.SlideParts.Skip(0).First();  // this will retrieve your second slide
                chartPart = secondSlidePart.ChartParts.First();
                chartPartIdBookMark = secondSlidePart.GetIdOfPart(chartPart);
                
                //Console.WriteLine("ID:"+chartPartIdBookMark.ToString());
                secondSlidePart.DeletePart(chartPart);
                secondSlidePart.Slide.Save();
                newChartPart = secondSlidePart.AddNewPart<ChartPart>(chartPartIdBookMark);
                ChartPart saveXlsChart = null;
                using (SpreadsheetDocument xlsDocument = SpreadsheetDocument.Open(SourceFile.ToString(), true))
                {
                    WorkbookPart xlsbookpart = xlsDocument.WorkbookPart;
                    foreach (var worksheetPart in xlsDocument.WorkbookPart.WorksheetParts)
                    {
                        if (worksheetPart.DrawingsPart != null)
                            if (worksheetPart.DrawingsPart.ChartParts.Any())
                            {
                                saveXlsChart = worksheetPart.DrawingsPart.ChartParts.First();
                            }
                    }
                    newChartPart.FeedData(saveXlsChart.GetStream());
                    //newChartPart.FeedData(
                    secondSlidePart.Slide.Save();
                    xlsDocument.Close();
                    pptPackage.Close();
                }
            }
        }

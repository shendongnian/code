                using xlNS = Microsoft.Office.Interop.Excel;
                using Microsoft.Office.Interop.PowerPoint;
                xlNS.ApplicationClass excelApplication = null;
                xlNS.Workbook excelWorkBook = null;
                xlNS.Worksheet targetSheet = null;
                xlNS.ChartObjects chartObjects = null;
                xlNS.ChartObject existingChartObject = null;
                Microsoft.Office.Interop.PowerPoint.ShapeRange shapeRange = null;
                Microsoft.Office.Interop.PowerPoint.Slide CurSlide;
     
                excelApplication = new xlNS.ApplicationClass();//Create New Excel
                excelWorkBook = excelApplication.Workbooks.Open(Excelpath,
                     paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
                     paramMissing, paramMissing, paramMissing, paramMissing, paramMissing,
                     paramMissing, paramMissing, paramMissing, paramMissing);
                Ws = (Excel.Worksheet)excelWorkBook.Worksheets[6];//Your Sheet that contain Chart
                Ws.Activate();
                targetSheet = (xlNS.Worksheet)(excelWorkBook.Worksheets["SheetName"]);
                chartObjects = (xlNS.ChartObjects)(targetSheet.ChartObjects(paramMissing));
                existingChartObject = (xlNS.ChartObject)(chartObjects.Item(1));
                existingChartObject.Copy();
                shapeRange = CurSlide.Shapes.Paste();//Paste it to your Current Slide
                shapeRange.Left = 435;
                shapeRange.Top = 80; //Formatting your chart

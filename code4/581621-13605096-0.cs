    using OfficeOpenXml;
    using OfficeOpenXml.Style;
    using OfficeOpenXml.Drawing;
       
            FileInfo newFile = new FileInfo(@"C:\ExcelFiles\RoundedRectangle.xlsx");
            ExcelPackage pck = new ExcelPackage(newFile);
            //Add the Content sheet
            var ws = pck.Workbook.Worksheets.Add("MySheet");
            ws.View.ShowGridLines = false;
            var shape = ws.Drawings.AddShape("Description", eShapeStyle.RoundRect);
            shape.SetPosition(0, 5, 5, 5);
            shape.SetSize(400, 200);
            shape.Text = "Text inside the round rectangle";
            shape.Fill.Style = eFillStyle.SolidFill;
            shape.Fill.Transparancy = 20;
            shape.Border.Fill.Style = eFillStyle.SolidFill;
            shape.Border.LineStyle = eLineStyle.LongDash;
            shape.Border.Width = 1;
            shape.Border.Fill.Color = Color.Black;
            shape.Border.LineCap = eLineCap.Round;
            shape.TextAnchoring = eTextAnchoringType.Top;
            shape.TextVertical = eTextVerticalType.Horizontal;
            shape.TextAnchoringControl = false;
    
            pck.Save();

       protected void btnDownload_Click(object sender, EventArgs e)
       {
           ExcelPackage pck = new ExcelPackage();
           var ws = pck.Workbook.Worksheets.Add("Sample2");
           ws.Cells["A1"].Value = "Sample 2";
           ws.Cells["A1"].Style.Font.Bold = true;
           var shape = ws.Drawings.AddShape("Shape1", eShapeStyle.Rect);
           shape.SetPosition(50, 200);
           shape.SetSize(200, 100);
           shape.Text = "Sample 2 outputs the sheet using the Response.BinaryWrite method";
           Response.Clear();    
           Response.ClearHeaders();
           Response.BinaryWrite(pck.GetAsByteArray());
           Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
           Response.AddHeader("content-disposition", "attachment;  filename=Sample2.xlsx");
           Response.End();
      }

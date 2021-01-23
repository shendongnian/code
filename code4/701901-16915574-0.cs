    byte[] pdfFile= null;
    var obj = DBContext.MyTable.Where(x => x.ID == 1 ).SingleOrDefault().pdfColumn;
    pdfFile = obj.ToArray();
     if (pdfFile!= null)
       {
     Response.ClearHeaders();
     Response.Clear();
     Response.AddHeader("Content-Type", "application/pdf");
     Response.AddHeader("Content-Length", pdfFile.Length.ToString());
     Response.AddHeader("Content-Disposition", "inline; filename=sample.pdf");
     Response.BinaryWrite(pdfFile);
     Response.Flush();
     Response.End();
       }

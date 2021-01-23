      const string fName = @"C:\picture.bmp";
      FileInfo fi = new FileInfo(fName);
      long sz = fi.Length;
 
      Response.ClearContent();
      Response.ContentType = Path.GetExtension(fName);
      Response.AddHeader("Content-Disposition", string.Format("attachment; filename = {0}",System.IO.Path.GetFileName(fName)));
      Response.AddHeader("Content-Length", sz.ToString("F0"));
      Response.TransmitFile(fName);
      Response.End();

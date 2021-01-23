    string attachment = "attachment; filename=MyCsvLol.csv";
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.ClearHeaders();
    HttpContext.Current.Response.ClearContent();
    HttpContext.Current.Response.AddHeader("content-disposition", attachment);
    HttpContext.Current.Response.ContentType = "text/csv";
    HttpContext.Current.Response.AddHeader("Pragma", "public");
    
    var sb = new StringBuilder();
    foreach(var line in DataToExportToCSV)
      sb.AppendLine(TransformDataLineIntoCsv(line));
    
    HttpContext.Current.Response.Write(sb.ToString());
    HttpContext.Current.Response.End();

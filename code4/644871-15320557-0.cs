     Response.Clear();
     Response.ClearHeaders();
     Response.ClearContent();
     Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
     Response.AddHeader("Content-Type", "application/Excel");
     Response.ContentType = "application/vnd.xls";
     Response.AddHeader("Content-Length", file.Length.ToString());
     Response.WriteFile(file.FullName);
     Response.End();

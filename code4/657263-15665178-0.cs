         string filepath = AppPath + @"\Test.edd";
         HttpContext.Current.Response.ContentType = "application/octet-stream";
         HttpContext.Current.Response.AddHeader("Content-Disposition",
                  "attachment; filename=" + "Test.edd");
         HttpContext.Current.Response.Clear();
         HttpContext.Current.Response.WriteFile(filepath);
         HttpContext.Current.Response.End();

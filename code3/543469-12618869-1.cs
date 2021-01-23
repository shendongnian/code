     Response.AppendHeader("content-disposition", "attachment;filename=FileEName.xls");
     Response.Charset = "";
     Response.Cache.SetCacheability(HttpCacheability.NoCache);
     Response.ContentType = "application/vnd.ms-excel";
     Response.Write(tableHtml);
     Response.End();

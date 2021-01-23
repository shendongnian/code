    HttpContext httpCtx = System.Web.HttpContext.Current;
        
    httpCtx.Response.Clear();
    httpCtx.Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", fileName));
    httpCtx.Response.ContentType = "application/vnd.ms-excel";
    httpCtx.Response.Charset = "utf-8";
        
    httpCtx.Response.WriteFile(filePath);
        
    httpCtx.Response.End();

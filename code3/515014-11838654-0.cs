    public void ProcessRequest (HttpContext context) 
    {
      string id = context.Request["id"];
      if (!string.IsNullOrEmpty(id))
         {
           //read byte[] and other data from database based upon given ID
           byte []ar=//result from database
           string fileName=//filename 
           context.Response.ContentType = "Application/octet-stream";
           context.Response.AddHeader("Content-Length", ar.Length.ToString());
           context.Response.AddHeader("Content-Disposition", "attachment; filename=" +  fileName );
           context.Response.BinaryWrite(ar);
           context.Response.Flush();
           context.Response.End();
          }
    }

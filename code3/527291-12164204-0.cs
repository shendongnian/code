    public void ProcessRequest(HttpContext context)
    {
       context.Response.ContentType = "Application/mp3"; 
       context.Response.AppendHeader("Content-Disposition", "attachment; filename=mysong.mp3"); 
       context.Response.TransmitFile(Server.MapPath("~/Files/song.mp3")); 
    }
 

    public void ProcessRequest(System.Web.HttpContext context)
    {
       
       byte[] raw; 
       using(var ms = new MemoryStream()){
           Image myImage = GetFromDll();
           myImage.Save(ms, ImageFormat.Png);
           raw=ms.ToArray();
       }
       context.Response.ContentType = "image/png";
       context.Response.BinaryWrite(raw);
    }

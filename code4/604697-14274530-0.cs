    public void Page_Load(...)
    {
         using(Bitmap image = new Bitmap(1,1))
         using(MemoryStream stream = new MemoryStream())
         {
              image.Save(stream);
              Response.ContentType = "image/png";
              stream.WriteTo(Response.OutputStream);
              Response.End();
         }
    }

    using (Bitmap theImage = new Bitmap("My.image.aspx"))
    {
       using(MemoryStream stream = new MemoryStream())
       {
          theImage .Save(stream , System.Drawing.Imaging.ImageFormat.Png);
          stream .WriteTo(context.Response.OutputStream);
       }
    }

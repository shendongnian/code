    using(MemoryStream ms = new MemoryStream())
     {
       image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
       ms.WriteTo(context.Response.OutputStream);
     }

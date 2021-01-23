    WebRequest req = WebRequest.Create("https://appharbor.com/assets/images/stackoverflow-logo.png");
    WebResponse response = req.GetResponse();
    Stream stream = response.GetResponseStream();
    System.Drawing.Image image = System.Drawing.Image.FromStream(stream);
    using (MemoryStream ms = new MemoryStream())
    {
         image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
         ms.WriteTo(Response.OutputStream);
    }

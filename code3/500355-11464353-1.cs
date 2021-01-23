    using Convert=System.Convert;
    using MemoryStream=System.IO.MemoryStream;
    using Image=System.Drawing.Image;
    //...
    byte[] data = Convert.FromBase64String(base64String);
    using(var stream = new MemoryStream(data, 0, data.Length))
    {
      Image image = Image.FromStream(stream);
      //TODO: do something with image
    }

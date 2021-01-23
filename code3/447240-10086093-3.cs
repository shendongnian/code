    var buffer = new byte[1024];
    var bytes = new byte[0];
    using(var s = File.OpenRead(@"C:\logo.png"))
    {
        int read;
        while((read = s.Read(buffer, 0, buffer.Length)) > 0)
        {
            var newBytes = new byte[bytes.Length + read];
            Array.Copy(bytes, newBytes, bytes.Length);
            Array.Copy(buffer, 0, newBytes, bytes.Length, read);
            bytes = newBytes;
        }              
    }
    var c = new PictureServiceClient();
    c.ShowPicture(bytes);

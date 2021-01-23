    Stream gelenResim = context.Request.InputStream;
    if (gelenResim.Length == 0) 
    {
        e.Resim = "/Content/EmlakDetayImaj/Noimages.jpg";
    }
                
    string guidim = Guid.NewGuid().ToString().Substring(0, 4);
    var KaydetResimDosya = "/Content/EmlakDetayImaj/" + guidim + ".jpg";
    using (FileStream fileStream = System.IO.File.Create(context.Server.MapPath("~/Content/EmlakDetayImaj/" + guidim + ".jpg"), (int)gelenResim.Length))
    {
        byte[] bytesInStream = new byte[gelenResim.Length];
        gelenResim.Read(bytesInStream, 0, (int)bytesInStream.Length);
        fileStream.Write(bytesInStream, 0, bytesInStream.Length);
    }

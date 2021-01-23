    System.Drawing.Image img = System.Drawing.Image.FromFile("filename");
    byte[] imgContent;
    using (System.IO.MemoryStream m = new System.IO.MemoryStream())
    {
        img.Save(m, img.RawFormat);
        imgContent = new byte[m.Length];
        const int count = 4096;
        byte[] buffer = new byte[4096];
        for (int i = 0; i < m.Length; i += count)
        {
            m.Read(buffer, i, (m.Length - i < count ? (int)(m.Length - i) : count));
            buffer.CopyTo(imgContent, i);
        }
    }
    myResponse.myImage = imgContent;

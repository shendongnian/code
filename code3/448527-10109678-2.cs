    System.Drawing.Image img = System.Drawing.Image.FromFile("filename");
    using (System.IO.MemoryStream m = new System.IO.MemoryStream())
    {
        img.Save(m, img.RawFormat);
        myResponse.myImage = m.ToArray();
    }

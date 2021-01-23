    object dataByte = null;
    for (int i = 0; i < images.Count; i++)
    {
        System.IO.MemoryStream ms = new System.IO.MemoryStream();
        images[i].Save(ms, System.Drawing.Imaging.ImageFormat.Png);
        items.Add(ms.ToArray());
    }

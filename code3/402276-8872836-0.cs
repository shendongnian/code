    using (MemoryStream ms = new MemoryStream(onimg))
    {
        if (ms.Length > 0)
        {
            using (Bitmap bm = new Bitmap(ms))
            {
                bm.Save(@"C:\img.jpeg");
            }
        }
    }

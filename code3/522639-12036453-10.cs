    byte[] blob = new byte[(dr.GetBytes(11, 0, null, 0, int.MaxValue))];
    dr.GetBytes(11, 0, blob, 0, blob.Length);
    using (MemoryStream ms = new MemoryStream(blob))
    {
        Bitmap bm = (Bitmap)Image.FromStream(ms);
        using (MemoryStream msJpg = new MemoryStream())
        {
            bm.Save(msJpg, ImageFormat.Jpeg);
            game.gameImage = msJpg.ToArray();
        }
    }

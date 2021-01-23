    using (MemoryStream ms = new MemoryStream())
    {
        bitmap.Save(ms);
        writer.Write(ms.Length);
        ms.Position = 0;
        ms.CopyTo(writer.BaseStream);
    }

    using (MemoryStream ms = new MemoryStream(currentImageBytes))
    {
        pic.Data = TagLib.ByteVector.FromStream(ms);
        f.Tag.Pictures = new TagLib.IPicture[1] { pic };
        if (save)
            f.Save();
    }

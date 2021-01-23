    byte[] photo = null;
    
    if(model.Photo != null)
    {
        var stream = model.Photo.InputStream;
        stream.Position = 0;
    
        using(BinaryReader br = new BinaryReader(model.Photo.InputStream))
        {
            photo = br.ReadBytes(model.Photo.ContentLength);
        }
    }

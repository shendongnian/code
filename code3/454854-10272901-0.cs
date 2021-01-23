    foreach(var file in files)
    {
        var image = db.Images.SingleOrDefault(i => i.FileName == file);
        if (item == null)
        {
            image = new ImageFingerPrint() { FileName = file };
            db.Images.Add(image);
        }
        
        image.FingerPrint = fingerprint;
    }    
    db.SaveChanges();

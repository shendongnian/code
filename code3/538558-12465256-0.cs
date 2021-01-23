    public static void updatePhoto(string name, string albumName, string newName, string newPath)
    {
        using (var db = new EzPrintsEntities())
        {
            // Load photo
            var photo = db.Images.FirstOrDefault(i => i.Label == name && i.Album == albumName);
            if (photo == null)
            {
               // no matching photo - do something
            }
  
            // Update data
            photo.Label = newName;
            photo.Path = newPath; 
            db.SaveChanges();
        }
    }

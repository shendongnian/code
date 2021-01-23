    public void DeletePhotoFromDb(PropertyPhotos photo)
        {
            db.PropertyPhotos.Remove(photo);
            db.SaveChanges(); // Missing this line
        }

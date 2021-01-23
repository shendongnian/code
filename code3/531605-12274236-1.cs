    var imageMeta = new ImageMeta
        {
            Name = imageForm.Name,
            UserId = Profile.Id,
        };
    ...
    db.Images.Add(imageMeta);
    db.SaveChanges();

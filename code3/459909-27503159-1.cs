    var mediaItem = db.MediaItems.FirstOrDefault(x => x.Id == mediaItemViewModel.Id);
        mediaItem.Name = mediaItemViewModel.Name;
        mediaItem.Description = mediaItemViewModel.Description;
        mediaItem.ModifiedDate = DateTime.Now;
        mediaItem.FileName = mediaItem.FileName;
        mediaItem.Size = KBToMBConversion(mediaItemViewModel.Size);
        mediaItem.Type = mediaItem.Type;
     
    //db.Entry(mediaItem).State = EntityState.Modified;// coment This line
    db.SaveChanges();

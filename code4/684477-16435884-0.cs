    List<Media> libraryItems = MediaHelper.GetChildrenMedia(this.CurrentContent.GalleryPicker.Value);
    public List<Media> GetChildrenMedia(Gallery gallery)
    {
        List<Media> output = repository.Media
            .Where(m => m.GalleryId == gallery.Id)
            .ToList();
        return output;
    }

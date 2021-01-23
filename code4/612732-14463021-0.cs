    public string TitleImageSource
    {
        get
        {
            return string.format(@"/files/thumbnails/{0}{1}", this.Title, fileType);
        }
    }

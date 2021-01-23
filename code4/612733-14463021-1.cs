    public string TitleImageSource
    {
        get
        {
            return string.Format(@"/files/thumbnails/{0}{1}", this.Title, fileType);
        }
    }

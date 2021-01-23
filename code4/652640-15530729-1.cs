    public string ImageUrl
    {
        get { return (List<string>)GetValue(ImageUrlProperty); }
        set
        {
            foreach (ImageUrl url in value)
            {
                SetValue(ImageUrlProperty, url);
            }
        }
    }

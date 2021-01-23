    public string ImageUrl
    {
        get { return (string)GetValue(ImageUrlProperty); }
        set
        {
            foreach ImageUrl url in value
            {
                SetValue(ImageUrlProperty, url); }
            }
        }
    }

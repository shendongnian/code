    [Category("Appearance"), DefaultValue("Description for the new page."), Description("The subtitle of the page."), Editor(typeof(MultilineStringEditor), typeof(UITypeEditor))]
    [Localizable(true)]
    public string Subtitle
    {
        get { return subtitle; }
        set
        {
            if (subtitle != value)
            {
                Region regionToInvalidate = GetTextRegionToInvalidate();
                subtitle = value;
                regionToInvalidate.Union(GetTextRegionToInvalidate());
    
                Invalidate(regionToInvalidate);
            }
        }
    }

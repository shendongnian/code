    if (null != _frontImage)
    {
        if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
        {
            Delay.LowProfileImageLoader.SetUriSource(_frontImage, ((BitmapImage) this.Source).UriSource);
        }
    }

    private void RefreshImage()
    {
        BitmapImage image = ImageHolder.Source as BitmapImage;
        ImageHolder.Source = null;
        
        DisposeImage(image);
        ImageHolder.Source = new BitmapImage(new Uri("000\\image" + (pageNum + 1).ToString("D3") + ".jpg", UriKind.Relative));
        RefreshTextData();
    }

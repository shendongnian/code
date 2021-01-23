    void Test()
    {
        ImageType2 image = new ImageType2();
    ...
        foreach(var size in image.Sizes)
        {
            if(IsTooBig(size))
            {
                MessageBox.Show("I'm too big!")l
            }
        }
    }
    
    bool IsTooBig(IImageSize imagesize)
    {
        return imagesize.Width > 500;
    }

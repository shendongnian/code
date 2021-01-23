    public UpdateImage(Image<Bgr, byte> imResult)
    {
        this.imResult = imResult;
        picBoxMatches.Image = imResult.ToBitmap();
    }

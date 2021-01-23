    public ImageSource GetImage(int width, int height)
    {
        string uri = string.Format("http://localhost:8000/Service/picture/{0}/{1}", width, height);
        return BitmapFrame.Create(new Uri(uri));
    }

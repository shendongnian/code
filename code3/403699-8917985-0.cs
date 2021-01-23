    public void LoadImage(string uri)
    {
        WebClient wc = new WebClient();
        wc.OpenReadCompleted += new OpenReadCompletedEventHandler(wc_OpenReadCompleted);
        wc.OpenReadAsync(new Uri(uri));
    }
    private void wc_OpenReadCompleted(object sender, OpenReadCompletedEventArgs e)
    {
        BitmapImage bi = new BitmapImage();
        bi.SetSource(e.Result);             // Here, you got your image
    }

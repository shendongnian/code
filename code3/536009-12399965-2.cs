    private Image LoadImage(string url)
    {
        System.Net.WebRequest request =
            System.Net.WebRequest.Create(url);
        System.Net.WebResponse response = request.GetResponse();
        System.IO.Stream responseStream =
            response.GetResponseStream();
        Bitmap bmp = new Bitmap(responseStream);
        responseStream.Dispose();
        return bmp;
    }

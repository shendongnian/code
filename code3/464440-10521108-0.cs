    public static Image GetExternalImg(string name, string size)
    {
        // Get the image from the web.
        WebRequest req = WebRequest.Create(String.Format("http://www.picturesite.com/picture.png", name, size));
        // Read the image that we get in a stream.
        Stream stream = req.GetResponse().GetResponseStream();
        // Save the image from the stream that we are rreading.
        Image img = Image.FromStream(stream);
        // Save the image to local storage.
        img.Save(Environment.CurrentDirectory + "\\images\\" + name + ".png");
        return img;
    }

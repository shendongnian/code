       HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(ImageButton1.ImageUrl);
        request.Method = "HEAD";
        try
        {
            request.GetResponse();
        }
        catch
        {
            ImageButton1.ImageUrl = "yournewimage.jpg";
        }

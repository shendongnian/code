    using (var wc = new WebClient())
    {
        using (var imgStream = new MemoryStream(wc.DownloadData(imgUrl)))
        {
            using (var objImage = Image.FromStream(imgStream))
            {
                //do stuff with the image
            }
        }
    }

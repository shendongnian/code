    using (WebClient wc = new WebClient())
    {
        using (Stream s = wc.OpenRead("http://hell.com/leaders/cthulhu.jpg"))
        {
            using (Bitmap bmp = new Bitmap(s))
            {
                bmp.Save("C:\\temp\\octopus.jpg");
            }
        }
    }

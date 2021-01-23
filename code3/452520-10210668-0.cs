    protected void DiasShow()
    {
        var mapPath = HttpContext.Current.Server.MapPath("/CSS/Design/Page_Design/Dias/1920x1080/");
        var images =
            Directory.GetFiles(mapPath).Select(
                file => new FileInfo(file)).Where(fi =>
                    fi.Extension.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                    fi.Extension.EndsWith("jpeg", StringComparison.OrdinalIgnoreCase)).ToList();
        var rand = new Random();
        while (images.Count > 0)
        {
            var i = rand.Next(images.Count);
            lbl_Dias.Text += "<img src=\"CSS/Design/Page_Design/Dias/1920x1080/" + images[i].Name + "\"/>";
            images.RemoveAt(i);
        }
    }

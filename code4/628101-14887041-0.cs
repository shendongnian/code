    AlternateView html = message.AlternateViews.FirstOrDefault(v => v.ContentType.Name == "text/html");
    if (html != null)
    {
        LinkeResource img = new LinkedResource(imgFileName, imgMimeType);
        img.ContentId = imgContentName;
        html.AddLinkedResources.Add(img);
    }

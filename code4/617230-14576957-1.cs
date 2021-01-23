    public ActionResult Download(string url, string cnt)
    {
        if (!string.IsNullOrEmpty(url) && !string.IsNullOrEmpty(cnt) && File.Exists(url))
        {
            return File(url, cnt);
        }
        return HttpNotFound();
    }

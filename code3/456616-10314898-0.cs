    public ActionResult SitePowered()
    {
        var dateTime = new DateTime(2012, 4, 1);
        var totalSeconds = (DateTime.Now - dateTime).TotalSeconds;
        return Json(new { seconds = totalSeconds });
    }

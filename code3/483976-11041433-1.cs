    [HttpPost]
    public ActionResult Create(VideoSermons video, HttpPostedFileBase videoFile)
    {
        var videoDb = new VideoSermonDb();
        try
        {
            video.Path = Path.GetFileName(videoFile.FileName);
            video.UserId = HttpContext.User.Identity.Name;
            videoDb.Create(video);
            if (videoFile != null && videoFile.ContentLength > 0)
            {
                var videoName = Path.GetFileName(videoFile.FileName);
                var videoPath = Path.Combine(Server.MapPath("~/Videos/"),
                                             System.IO.Path.GetFileName(videoFile.FileName));
                videoFile.SaveAs(videoPath);
            }
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

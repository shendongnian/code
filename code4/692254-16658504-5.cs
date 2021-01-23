    public ActionResult CreateNewChannel(GuiChannel channel, int? userId, SelectGenrePostModel model)
    {
        if (userId.HasValue)
        {
            // do work here
            return RedirectToAction("SelectChannel", new { channelId = channelId, userId = userId });
        }
        return RedirectToAction("Index", "Home");
    }

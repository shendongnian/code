    [HttpPost]
    public ActionResult AddToMyMp3s(Mp3 sermons)
    {
        var myMp3s = new MyMp3Db();
        var mySermons = new MyMp3();
        try
        {
            mySermons.UserId = HttpContext.User.Identity.Name;
            mySermons.MyMp3sId = sermons.Mp3Id;
            myMp3s.Create(mySermons);
            return RedirectToAction("Index");
        }
        catch
        {
            return RedirectToAction("Index");
        }
    }

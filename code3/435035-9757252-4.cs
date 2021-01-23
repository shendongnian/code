    [HttpPost]
    public ActionResult SomeAction()
    {
        var file = Request.Files["file"];
        if (file != null && file.ContentLength > 0)
        {
            var filename = Path.GetFileName(file.FileName);
            filename = Path.Combine(Server.MapPath("~/uploads"), filename);
            file.SaveAs(filename);
        }
        return View();
    }

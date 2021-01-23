    [HttpPost]
    public ActionResult SomeAction(HttpPostedFileBase file)
    {
        if (file != null && file.ContentLength > 0)
        {
            var filename = Path.GetFileName(file.FileName);
            filename = Path.Combine(Server.MapPath("~/uploads"), filename);
            file.SaveAs(filename);
        }
        return View();
    }

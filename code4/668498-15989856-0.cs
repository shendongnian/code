    // controller
    public ActionResult MyAction()
    {
        ...
        ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/images_upload"));
        return View(...);
    }
    // view
    @foreach(var image in (IEnumerable<string>)ViewBag.Images))
    {
        <img src="@Url.Content("~/images_upload" + image)" alt="Hejsan" />
    }

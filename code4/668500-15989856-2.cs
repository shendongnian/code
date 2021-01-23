    // controller
    public ActionResult MyAction()
    {
        ...
        ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/images_upload"))
                                  .Select(fn => "~/images_upload/" + Path.GetFileName(fn));
        return View(...);
    }
    // view
    @foreach(var image in (IEnumerable<string>)ViewBag.Images))
    {
        <img src="@Url.Content(image)" alt="Hejsan" />
    }

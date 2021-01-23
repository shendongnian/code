    // model
    class MyViewModel
    {
        public IEnumerable<string> Images { get; set; }
    }
    // controller
    public ActionResult MyAction()
    {
        var model = new MyViewModel()
        {
            Images = Directory.EnumerateFiles(Server.MapPath("~/images_upload"))
                              .Select(fn => "~/images_upload/" + Path.GetFileName(fn));
        }
        return View(model);
    }
    // view
    @foreach(var image in Model.Images))
    {
        <img src="@Url.Content(image)" alt="Hejsan" />
    }

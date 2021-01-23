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
            Images = Directory.EnumerateFiles(Server.MapPath("~/images_upload"));
        }
        return View(model);
    }
    // view
    @foreach(var image in Model.Images))
    {
        <img src="@Url.Content("~/images_upload" + image)" alt="Hejsan" />
    }

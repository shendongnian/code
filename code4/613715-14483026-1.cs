    public class IndexViewModel
    {
        public string Title { get; set; }
        public bool IsAuthenticated { get; set; }
    }
    ....
    public ActionResult Index()
    {
        return View(new IndexViewModel()
        {
            Title = "Index",
            IsAuthenticated = UserIsLoggedIn()
        });
    }

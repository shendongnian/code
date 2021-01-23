    public class Model
    {
        public IEnumerable<SelectListItem> AllLocations { get; set; }
        public IEnumerable<SelectListItem> TopLocations { get; set; }
        public IEnumerable<SelectListItem> AllTemplates { get; set; }
        public IEnumerable<SelectListItem> TopTemplates { get; set; }
        // ...
    }
    
    [HttpGet]
    public ActionResult Index(int id)
    {
        var domain = Repository.Get(id);
        var model = Mapper.Map<Domain, ViewModel>(item);
        InitializeSelectLists(model);
    
        return View(model);
    }
    
    [HttpPost]
    public ActionResult Index(ViewModel model)
    {
        InitializeSelectLists(model);
        View(model);
    }
    
    
    private void InitializeSelectLists(Model model)
    {
        model.AllLocations = new SelectList(repository.GetAllLocations(), "Value", "Text");
        model.TopLocations = new SelectList(repository.GetTopLocations(), "Value", "Text");
        model.AllTemplates = new SelectList(repository.GetAllTemplates(), "Value", "Text");
        model.TopTemplates = new SelectList(repository.GetTopTemplates(), "Value", "Text");
        // etc. etc.
    }

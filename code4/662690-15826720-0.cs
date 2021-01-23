    public class IndexViewModel
    {
        // Stores the selected value from the drop down box.
        [Required]
        public int CountryID { get; set; }
     
        // Contains the list of countries.
        public SelectList Countries { get; set; }
    }
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.Countries = new SelectList(GetCountries(), "ID", "Name");
            return View(viewModel);
        }
     
        [HttpPost]
        public ActionResult Index(IndexViewModel viewModel)
        {
            viewModel.Countries = new SelectList(GetCountries(), "ID", "Name");
            if (!ModelState.IsValid)
                return View(viewModel);
     
            //TODO: Do something with the selected country...
            CMSService.UpdateCurrentLocation(viewModel.CountryID);
     
            return View(viewModel);
        }
    }

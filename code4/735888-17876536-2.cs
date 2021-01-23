    public class CascadeListController : Controller
    {
         private readonly IStateRepository stateRepository;
         private readonly IDistrictRepository districtRepository;
    
         public LocationController(IStateRepository stateRepository, IDistrictRepository districtRepository)
         {
              this.stateRepository = stateRepository;
              this.districtRepository = districtRepository;
         }
    
         public ActionResult Create()
         {
              LocationViewModel viewModel = new LocationViewModel
              {
                   States = stateRepository.GetAll(),
                   Districts = Enumerable.Empty<District>() // Empty because no state has been selected
              };
    
              return View(viewModel);
         }
    
         [HttpPost]
         public ActionResult Create(LocationViewModel viewModel)
         {
              // Do whatever you need to do here
         }
    }

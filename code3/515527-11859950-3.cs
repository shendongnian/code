    public class HospitalController : Controller
    {
         private readonly IHospitalRepository hospitalRepository;
    
         public HospitalController(IHospitalRepository hospitalRepository)
         {
              // Check that hospitalRepository is not null
    
              this.hospitalRepository = hospitalRepository;
         }
    
         public ActionResult Create()
         {
              DoctorHospitalViewModel viewModel = new DoctorHospitalViewModel
              {
                   Hospitals = hospitalRepository.GetAll()
              };
    
              return View(viewModel);
         }
    
         [HttpPost]
         public ActionResult Create(DoctorHospitalViewModel viewModel)
         {
              // Check that viewModel is not null
    
              if (!ModelState.IsValid)
              {
                   viewModel.Hospitals = hospitalRepository.GetAll();
    
                   return View(viewModel);
              }
    
              // Do what ever needs to be done
              // You can get the selected hospital id like this
              int selectedHospitalId = viewModel.HospitalId;
    
              return RedirectToAction("List");
         }
    }

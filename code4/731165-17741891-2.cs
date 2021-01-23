    public class BookingController : Controller
    {
         private readonly IAttractionRepository attractionRepository;
    
         public BookingController(IAttractionRepository attractionRepository)
         {
              this.attractionRepository = attractionRepository;
         }
    
         public ActionResult NewBooking()
         {
              BookingViewModel viewModel = new BookingViewModel
              {
                   Attractions = attractionRepository.GetAll()
              };
    
              return View(viewModel);
         }
    
         [HttpPost]
         public ActionResult NewBooking(BookingViewModel viewModel)
         {
              // Check for null viewModel
              if (!ModelState.IsValid)
              {
                   viewModel.Attractions = attractionRepository.GetAll();
                   return View(viewModel);
              }
              // Do whatever else you need to do here
         }
    }

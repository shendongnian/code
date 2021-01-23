    public class BookingController : Controller
    {
         private readonly IBookingManager bookingManager;
    
         public BookingController(IBookingManager bookingManager)
         {
              this.bookingManager = bookingManager;
         }
    
         public ActionResult Index()
         {
              BookingViewModel viewModel = new BookingViewModel
              {
                   Tickets = bookingManager.GetAllTickets().ToList()
              };
    
              return View(viewModel);
         }
    }

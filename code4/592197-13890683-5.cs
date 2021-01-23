    public class FooController : Controller
    {
         public IMappingEngine Mapping { get; set; } // Thing from automapper.
         public ITicketsRepository TicketsRepository { get; set; }
         public ViewResult Tickes()
         { 
             return View(TicketsRepository.GetAllForToday().Project(Mapping)
                 .To<TicketViewModel>().ToArray();
         }
    }

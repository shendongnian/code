    public class EventsController : Controller
    {
        private readonly IEventService eventService;
        public EventsService()
        {
            this.eventsService = new EventsService(new Entities());
        }
        // action that gets and views the active events
        public ActionResult Active()
        {
            var activeEvents = this.eventsService.Getactive();
            return View(activeEvents);
        }
    }

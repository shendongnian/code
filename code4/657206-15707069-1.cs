    public class ScheduleController : Controller
    {
        readonly ModelServices _mobjModel = new ModelServices();
        public ActionResult Index()
        {
            var schedules = _mobjModel.GetSchedules();
            return View(schedules);
        }
        public ActionResult Filter(string description)
        {
            var schedules = _mobjModel.GetSchedules();
            if (!string.IsNullOrEmpty(description))
            {
                schedules = schedules.Where(s => s.Description.ToLower().Contains(description.ToLower())).ToList();
            }
            return PartialView("_grid", schedules);
        }
    }

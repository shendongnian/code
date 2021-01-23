    public class HomeController : Controller
    {
        public ReportsViewModel Model { get; set; }
        //
        // GET: /Reports/
        public ActionResult Index()
        {
            Model = new ReportsViewModel
            {
                Units = UnitClient.GetListOfUnits(true, "")
            };
            return View(Model);
        }
        [HttpGet]
        public ActionResult UnitRunReport(string selectedUnit)
        {
            var unit = Convert.ToInt32(selectedUnit);
            Model = new ReportsViewModel
            {
                UnitRuns = RunClient.GetRunListForUnit(unit)
            };
            return this.Json(Model, JsonRequestBehavior.AllowGet);
        }
    }

    public class DController : Controller
    {
        //GET /d
        public ActionResult Index()
        {
            //MyModel is a class that would contain the logic to display
            //the selections from A, B, and C
            var model = new MyModel();
            return View(model);
        }
        //POST /d/saveresults
        //We only want this method to accept POST
        [HttpPost]
        public ActionResult SaveResults(MyEntity data)
        {
            var model = new MyModel();
            model.SaveResultsToDatabase(data);
            
            return Redirect("/");
        }
    }

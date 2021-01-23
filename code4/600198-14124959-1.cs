    public class PersonsController : Controller
    {
        public ActionResult Index()
        {
            var model = new[] 
            {
                new Person()
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<Person> persons)
        {
            if (!ModelState.IsValid)
            {
                return View(persons);
            }
            // To do: do whatever you want with the data
            // In this example I am simply dumping it to the output
            // but normally here you would update your database or whatever
            // and redirect to the next step of the wizard
            return Content(string.Join(Environment.NewLine, persons.Select(p => string.Format("name: {0} address: {1}", p.FullName, p.Address))));
        }
        public ActionResult BlankEditorRow()
        {
            return PartialView("_PersonEditorRow", new Person());
        }
    }

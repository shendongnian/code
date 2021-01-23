    public class PersonController : Controller
    {
          static List<Person> people = new List<Person>();
          public ActionResult Index()
          {
              return View(people);
          }
          public ActionResult Details(Person person)
          {
              return View(person);
          }
          public ActionResult Create()
          {
              return View();
          } 
          [AcceptVerbs(HttpVerbs.Post)]
          public ActionResult Create(Person person)
          {
              if (!ModelState.IsValid)
              {
                  return View("Create", person);
              }
              people.Add(person);
              return RedirectToAction("Index");
          }
      }

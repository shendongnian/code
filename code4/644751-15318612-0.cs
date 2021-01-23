    namespace MvcApplication1.Controllers
    {
        public class HomeController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
            [HttpPost]
            public JsonResult PostUser(UserModel data)
            {
                // test here!
                Debug.Assert(data != null);
                return Json(data);
            }
        }
        public class UserModel
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }

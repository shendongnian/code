    using System.Dynamic; // up top...
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            return View();
        }
        public ActionResult SomeDataSource(int id)
        {
            dynamic d = new { innerId = 99, innerLabel = "inside object" };
            SomeModelType obj = new SomeModelType(id, "new object");
            obj.SomeValue = d;
            return Json(obj, "text/plain");
        }
        public ActionResult SomeDataSourceWithArray(int id)
        {
            dynamic d1 = new { innerId = 99, innerLabel = "inside object (first array member)" };
            dynamic d2 = new { innerId = 100, innerLabel = "inside object (second array member)" };
            SomeModelType obj = new SomeModelType(id, "new object");
            obj.SomeValue = new object[] {d1, d2};
            return Json(obj, "text/plain");
        }
        public ActionResult SomeDataSourceWithExpando(int id)
        {
            dynamic d = new ExpandoObject();
            d.innerId = 99;
            d.innerLabel = "inside object";
            SomeModelType obj = new SomeModelType(id, "new object");
            obj.SomeValue = d;
            return Json(obj, "text/plain");
        }
    }
    public class SomeModelType
    {
        public SomeModelType(int initId, string initLabel)
        {
            Id = initId;
            Label = initLabel;
        }
        public int Id { get; set; }
        public string Label { get; set; }
        public dynamic SomeValue { get; set; }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            IEnumerable<Row> dict = new[] { new Row("1", 1), new Row("1", 2), new Row("1", 3), new Row("2", 2), new Row("2", 3), new Row("2", 4) };
            var grouped = dict.GroupBy(c => c.Key).First();
            //var grouplist = grouped.Select(c => new KeyValuePair<string, IEnumerable<int>> (c.Key, c.Select(b=>b.Value)));
            return View(grouped);
        }
        public ActionResult Post(IEnumerable<Row> Model)
        {
            return null;
        }
    }

    namespace SomeApp.Controllers {
    public class TestModel {        
        public IEnumerable<TestModelItem> Items { get; set; }
    }
    public class TestModelItem {
        public int Id { get; set; }
        public String Name { get; set; }
    }
    public class TestsController : Controller {
        
        public ActionResult Index() {
            TestModel tm = new TestModel {
                Items = new List<TestModelItem> {
                    new TestModelItem { Id = 1, Name = "first"},
                    new TestModelItem { Id = 2, Name = "second"}
                }
            };
            return View(tm);
        }
        [HttpPost]
        public ActionResult Index(TestModel tm) {
            return View(tm);
        }
    }
    }

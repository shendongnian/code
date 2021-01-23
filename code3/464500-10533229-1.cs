    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new Form
            {
                Fields = new[]
                {
                    new FieldValue { Field = new Field { IsRequired = true }, Value = "" },
                    new FieldValue { Field = new Field { IsRequired = true }, Value = "" },
                    new FieldValue { Field = new Field { IsRequired = false }, Value = "value 3" },
                }
            };
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(Form model)
        {
            return View(model);
        }
    }

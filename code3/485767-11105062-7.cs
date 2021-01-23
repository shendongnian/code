    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Initially we have 2 items in the database
            var model = new[]
            {
                new MyViewModel { Id = 2 },
                new MyViewModel { Id = 1 }
            };
            return View(model);
        }
        [HttpDelete]
        public ActionResult Index(MyViewModel[] model)
        {
            // simulate a validation error
            ModelState.AddModelError("", "some error occured");
            if (!ModelState.IsValid)
            {
                // We refetch the items from the database except that
                // a new item was added in the beginning by some other user
                // in between
                var newModel = new[]
                {
                    new MyViewModel { Id = 3 },
                    new MyViewModel { Id = 2 },
                    new MyViewModel { Id = 1 }
                };
                return View(newModel);
            }
            // TODO: here we do the actual delete
            return RedirectToAction("Index");
        }
    }

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            // Those are your domain models
            // they could come from a database or something
            var listA = new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5" };
            var listB = new[] { "Item 1", "Item 2", "Item 3", "Item 4", "Item 5", "Item 6", "Item 7", "Item 8", "Item 9", "Item 10" };
            // Now let's map our domain model to our view model
            var model = listB.Select(x => new MyViewModel
            {
                Name = x,
                IsChecked = listA.Contains(x)
            });
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(IEnumerable<MyViewModel> model)
        {
            var selectedItems = model.Where(x => x.IsChecked);
            var format = string.Join(",", selectedItems.Select(x => x.Name));
            return Content("Thank you for selecting " + format);
        }
    }

    public class ItemsController: Controller
    {
        public ActionResult Index()
        {
            var model = new MyViewModel
            {
                Items = new[]
                {
                    new SelectListItem { Value = "1", Text = "item 1" },
                    new SelectListItem { Value = "2", Text = "item 2" },
                    new SelectListItem { Value = "3", Text = "item 3" },
                }
            };
            return PartialView(model);
        }
    }

    public class ProductController : Controller
    {
        public ActionResult ProductDetails(string id)
        {
            MyProduct model = SomeDataSource.LoadByID(id);
            return View(model);
        }
    }

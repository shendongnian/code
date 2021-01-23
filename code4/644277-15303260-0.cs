    public class Manager : Controller
    {
        /* ... */
        [HttpPost]
        public ActionResult SendObj(IList<Int32> selectedItems)
        {
          // Grab those items by their IDs found within `selectedItems` and perform
          // any processing necessary
          // ...
          //return View();
        }
        /* ... */
    }

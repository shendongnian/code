    public class MyController : ExtendedController
    {
        public ActionResult MyAjaxOp()
        {
            List<int> MyList = new List<int>(); // Populate the list as required
            object MyHelperModel = new object(); // View Model as required
            object rtn = new { html = RenderPartialView("MyHelperView", MyHelperModel), list = MyList}
            return Json(rtn, JsonRequestBehavior.AllowGet);
        }
    }

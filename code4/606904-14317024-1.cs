    public class TestController
    {
        public ActionResult Test(string id)
        {
    		string valueResult = id; // process your result
            return Json(new { id: valueResult, name = 'User' }, JsonRequestBehavior.AllowGet.);
        }
    }

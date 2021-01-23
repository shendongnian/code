    public class YourController
    {
        [HttpGet]
        public ActionResult PostMethod()
        {
            YourModel model = new YourModel();
            return View(model);
        }
        [HttpPost]
        public ActionResult PostMethod(YourModel model)
        {
            //Do something with model.MyText;
            System.Threading.Thread.Sleep(5000);
            return Json("And We're Done");
        }
    }

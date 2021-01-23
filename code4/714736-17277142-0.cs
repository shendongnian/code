        public class PartnerController : Controller
        {
            public ActionResult Registration()
            {
                var model = new PartnerAdditional();
                new Action(MyTest).BeginInvoke(null, null);
                return View(model);
            }
    
            public void MyTest()
            {
                System.Threading.Thread.Sleep(10000);
                System.Diagnostics.Debug.WriteLine("ASYNC");
            }
    }

        public class PartnerController : Controller
        {
        public ActionResult Registration()
        {
            var model = new PartnerAdditional();
            model.ValidFrom = DateTime.Today;
            new Action<System.Web.HttpRequestBase>(MyAsync).BeginInvoke(this.HttpContext.Request, null, null);
            return View(model);
        }
        private void MyAsync(System.Web.HttpRequestBase req)
        {
            System.Threading.Thread.Sleep(5000);
            foreach (var item in req.Cookies)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
        }
    }

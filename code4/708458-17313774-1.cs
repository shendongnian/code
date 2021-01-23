    using System.Collections.Generic;
    using System.Web.Mvc;
    using Ext.Net;
    using Ext.Net.MVC;
    namespace Work2MVC.Controllers
    {
        public class AspxController : Controller
        {
            public ActionResult Index()
            {
                return View();
            }
            public ActionResult SubmitSelected(string values)
            {
                List<SomeEntity> data = JSON.Deserialize<List<SomeEntity>>(values);
                return this.Direct(data.Count);
            }
        }
    }

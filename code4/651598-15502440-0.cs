    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace TestPortal.Areas.JB.Controllers
    {
        public class ExampleController : Controller
        {
            //
            // GET: /JB/Example/
            public ActionResult Index()
            {
                Models.Example.ExampleIndex output = new Models.Example.ExampleIndex();
                output.DropDownData.Add(new SelectListItem()
                {
                    Text = "One",
                    Value = "1"
                });
                output.DropDownData.Add(new SelectListItem()
                {
                    Text = "Two",
                    Value = "2"
                });
                return View(output);
            } 
        }
    }

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using testapplication.Models;
    
    namespace testapplication.Controllers {
        public class HomeController : Controller {
    		private static testapplication.Models.testModel testModel;
    	
            public ActionResult Index() {
                testModel.CreateList1();
                testModel.FillList1();
                testModel.FillList2();
                var var1 = testModel.list1;
                var var2 = testModel.list2;
                var var3 = testModel.list3;
                return View();
            }
    
            [HttpPost]
            public ActionResult Index(string test) {           		
    			var var1 = testModel.list1;
                var var2 = testModel.list2;
                var var3 = testModel.list3;
                return View();
            }
        }
    }

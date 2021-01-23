    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    namespace MvcApplication1.Controllers
    {
        public class ProductController : Controller
        {
            //
            // GET: /Product/
            public ActionResult Index(String startString)
            {
                List<Models.Product> theProducts;
                using (
                    Models.NorthwindEntities NWC = 
                    new Models.NorthwindEntities()
                )
                {
                     theProducts =
                        (from e in NWC.Products
                         where e.ProductName.StartsWith(startString)
                        select e).ToList();
                }
                return View(theProducts);
            }
        }
    }

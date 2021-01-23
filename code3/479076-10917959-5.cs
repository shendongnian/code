        public ActionResult _Partial1(ProductSearch search)
        {
            Product Product1 = ProductsToSearch().Where(a => a.Class.Equals(search.q) && a.Type.Equals("High")).SingleOrDefault();
            search.Product1 = Product1;
            return PartialView(search);
        }
        public ActionResult _Partial2(ProductSearch search)
        {
            Product Product2 = ProductsToSearch().Where(a => a.Class.Equals(search.q) && a.Type.Equals("Low")).SingleOrDefault();
            search.Product2 = Product2;
            return PartialView(search);
        }
        [HttpPost]
        public ActionResult ActualView(ProductSearch search)
        {
            return View(search);
        }
        public ActionResult ActualView()
        {
            ProductSearch search = new ProductSearch();           
            return View(search);
        }
           

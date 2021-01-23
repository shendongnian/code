        public ActionResult Index()
        {
            ObjectResult<getProductsListForHome_Result> products = db.getProductsListForHome(1, 14);
            List<bm_products> viewProducts = products.Select(p => new bm_products{/*set properties here*/}).ToList();
            
            return View(viewProducts);
        }

        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to ASP.NET MVC!";
            CurrentDealModel model = new CurrentDealModel();
            model.DealQueueDetails = db.FirstOrDefault<ProductQueue>("SELECT * FROM ProductQueue WHERE Active = 1");
            model.ProductDetails = db.FirstOrDefault<Product>("WHERE Id = @0", model.DealQueueDetails.ProductId);
            var DealTime = model.DealQueueDetails.DealTimeLimit;
            var CurrentTime = System.DateTime.Now;
            TimeSpan span = DealTime.Subtract(CurrentTime);
            var model1 = HttpContext.Cache.Get(model.DealQueueDetails.Id.ToString());
            if (model1 == null)
            {
                model1 = HttpContext.Cache.Add(model.DealQueueDetails.Id.ToString(), model, null, System.DateTime.Now.Add(span).AddSeconds(10), Cache.NoSlidingExpiration, CacheItemPriority.High, new CacheItemRemovedCallback(RedirectToNewDeal));
                var CachedObject = HttpContext.Cache.Get(model.DealQueueDetails.Id.ToString());
                return View(CachedObject);
            }
            return View(model1);
        }

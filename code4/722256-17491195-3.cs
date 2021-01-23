        [HttpGet]
        public ActionResult MyView()
        {
           var units = _context.Units.Where(//whatever);
           
           var viewModels = units.Select(u => new UnitViewModel()
                                               {
                                                   Unit=u,
                                                   TradeCount =
                                                          context.Trades.Where(t => t.name == u.name).Count()
                                                 });
           return View(viewModels);
        
        }

            public ActionResult Create()
                {
                var rd = RouteData.Values["jobno"];
                var query = (from t in _db.table3
                             join d in _db.table2 on t.delivery_number equals d.ID
                             join m in _db.table4 on d.OrderNo equals m.JobNo
                             where m.JobNo == rd
                             select new
                                  {
                                      t.rev_delivery_number
                                  });
                        
            
                 IEnumerable<SelectListItem> rev_del = query
                            .Select(c => new SelectListItem
                            {
                                Value = c.rev_delivery_number,
                                Text = c.rev_delivery_number
                            });
            
            
                 ViewBag.Rev = rev_del;
            
                
                 return View();
                 }
        
            
            
            
                    [HttpPost]
                    public ActionResult Create(Table1 table1)
                    {
            
                        
            
                        if (ModelState.IsValid)
                        {
                            _db.Table1.Add(table1);
                            _db.SaveChanges();
                            return RedirectPermanent("Index");
            
                            
                        }
            
                        return View(table1);
                    }

    [HttpPost]
    public ActionResult Index(SearchClass search) {
       var model = _db.Contacts;
       if (!string.IsNullOrWhiteSpace(search.FirstName))
           model = model.Where(m => m.FirstName.StartsWith(search.FirstName));
    
       if (!string.IsNullOrWhiteSpace(search.LastName))
           model = model.Where(m => m.LastName.StartsWith(search.LastName));
    
       var result = model
                .OrderBy(c => c.FirstName)
                .Take(5)
                //etc.
       
    }

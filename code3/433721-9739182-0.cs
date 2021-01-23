    public virtual ActionResult Search(string term)
    {
        var clientNames = from customer in DocumentSession.Query<Customer>()
                            select new { label = customer.FullName };
    
        var results = from name in clientNames.ToArray()
                        where name.label.Contains(term,
                                                 StringComparison.CurrentCultureIgnoreCase)
                        select name;
    
        return Json(results.ToArray(), JsonRequestBehavior.AllowGet);
    }

    public ActionResult BusinessDetails()
    {               
        int bsId = bskey ?? default(int);
        var business = GetContactBusinessById(bsId);    
        return PartialView("_EditBusiness", business);
    }
    public t_BUSINESS GetContactBusinessById(int id)
    {
        if (id == 0)
        {
            return null;
        }
        var query = 
            from b in db.t_BUSINESS
            from p in b.t_PEOPLE
            where b.BS_KEY == id && p.PP_IS_CONTACT
            select b;
        return query.FirstOrDefault();
    }

    public List<ReviewModule> GetReviewsInModule(int id)
    {
        Context con = new Context();
        con.Configuration.ProxyCreationEnabled = false;
        var mod = con.Modules.Find(id);
        if (mod == null) throw new WebServiceValidationException("Object does not exist");
        List<ReviewModule> revs = con.ModuleReviews.Include("User").Where(r => r.Module.Id == id).ToList();
        return revs;
    }

    public ActionResult Search(string filter)
    {
       var parts = filter.Split("|".ToCharArray());
    
       Filter model = new Filter();
       model.Id = Int32.Parse(parts[0]);
    
       // ...
    }

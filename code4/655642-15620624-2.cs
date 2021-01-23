    public ActionResult Filter(string name, string email){
     //name and email are the filter values
     var query = ( from c in (List<Bug>)itemList select c);
    if(!string.IsNullOrEmpty(name))
      query.AddWhere(c => c.Name == name);
    
    if(!string.IsNullOrEmpty(email))
      query.AddWhere(c => c.Email == email);
    
    
    }

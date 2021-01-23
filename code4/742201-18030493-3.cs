      public List<Item> SubItems{
      get
      {
       try{
            var validParents = db.items.Where(x=>x.ParentId!=null && x.ParentId.Equals(Id)); //db is your dbcontext
            if(validParents !=null)
            {
               return validParents.ToList(); 
            }else
            {
             return null;
            } 
            catch(Exception)
            {
              return null;
            }
       }

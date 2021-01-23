        var t = _db.Blog.Where(x => x.ID == id).FirstOrDefault();
        
        var info = typeof(Blog).GetProperties();
    //properties you don't want to update
        var properties = info.Where(x => x.Name != "xxx" && x.Name != "xxxx").ToList();
      foreach(var p in properties)
       {
          p.SetValue(t, p.GetValue(temp.Volunteer));
       }
        
      
       _db.Entry(t).State = EntityState.Modified;
       _db.SaveChanges();

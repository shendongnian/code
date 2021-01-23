    public ActionResult Edit(Category cat)
    {
      //cat is the modified object
      using(MyEFEntities db = new MyEFEntities())
      {
        var dbCategory = db.Categories.FirstOrDefault(o => o.ID == cat.ID);
        dbCategory.Description = cat.Description.
        dbCategory.Value = cat.Value;
        db.SaveChanges();
      }
    }

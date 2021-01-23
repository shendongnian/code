    using (var ctx = new FCEntities())
    {
      var batch = new Batch() { Description = txtDescription.Text, Filename = filename};
      foreach (var department in lstDepartments.CheckedItems)
      {
        var dept = (from d in ctx.Departments where d.DepartmentID == ((Department)department).DepartmentID select d).First();
        batch.Departments.Add(dept);
      }
      ctx.Batches.AddObject(batch);
      ctx.SaveChanges();
    }

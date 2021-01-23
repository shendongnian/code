    private void Save()
    {
      var batches = new DataServiceCollection<Batch>(_ctx);
      var batch = new DataService.Batch() { Description = txtDescription.Text, Filename = txtFilename.Text };
      batches.Add(batch);
    
      foreach (var department in lstDepartments.CheckedItems)
      {
        var dept = _ctx.Departments
          .Select(d => d)
          .Where(d => d.DepartmentID == ((DataService.Department)department).DepartmentID)
          .First();
    
        batch.Departments.Add(dept);
      }
    
      // _ctx.AddToBatches(batch);
      _ctx.SaveChanges();
    }

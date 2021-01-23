    using (var uow = new UnitOfWork<CompanyContext>())
    {
      var catService = new Services.CategoryService(uow);
      var custService = new Services.CustomerService(uow);
     
      var cat = new Model.Category { Name = catName };
      catService.Add(dep);
     
      custService.Add(new Model.Customer { Name = custName, Category = cat });
                    
      uow.Save();
    }

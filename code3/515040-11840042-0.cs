    public Repository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public SalesController(ISalesRepository salesRepository, 
                              ISalesPeopleRepository salesPeopleRepository) 
    { 
       _salesRepository = salesRepository; 
       _salesPeopleRepository = salesPeopleRepository; 
    } 

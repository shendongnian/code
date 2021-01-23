    Public Class SomeService
    {
    
      ISomeServiceRepository someServiceRepository;
    
      public SomeService(ISomeServiceRepository someServiceRepository)
      {
        this.someServiceRepository = someServiceRepository
      }
    
      Public GetSomeThing()
      {
   
        someData = someServiceRepository.getData();
        ...
      }
    }

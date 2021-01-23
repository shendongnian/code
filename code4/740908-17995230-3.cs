    // example code
    using ( IUnitOfWork uow = new YourImplementationOfUnitOfWork() )
    {
       var animals = uow.AnimalRepository.Query.Where( a => a.NumberOfLegs == 3 );
       var person = uow.HumanRepository.CreateNew();
       person.Name = "John";
       uow.HumanRepository.Insert( person );
     
       uow.SaveChanges();
    }

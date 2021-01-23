    // example code
    using ( IUnitOfWork uow = new YourImplementationOfUnitOfWork() )
    {
       var animals = uow.AnimalRepository.FindByNumberOfLegs( 3 );
       var person = uow.HumanRepository.CreateNew();
       person.Name = "John";
       uow.HumanRepository.Insert( person );
     
       uow.SaveChanges();
    }

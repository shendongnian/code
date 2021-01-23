    class NameIsUnique<MyClass> : IRule<MyClass>
    {
         private readonly IRepository<TheEntity> repository;
         public NameIsUnique<MyClass>(IRepository<TheEntity> repository)
         {
             this.repository = repository;
         }
         public bool IsBroken(MyClass model)
         {
              return repository.Where(x => x.Name == model.Name).Any();
         }
         public ErrorMessage 
         { 
             get { return new ErrorMessage { Property = "Name", Message = "Name is not unique" }; } 
         }
    }

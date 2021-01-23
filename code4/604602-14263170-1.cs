    public class MyApp
    {
        IDomainObjectRepository repository = //TODO: Initialize a concrete SqlDomainObjectRepository that loads what we need.
        DomainObject do = repository[0]; //Get the one (or set) that we're working with.
        do.DoSomething(); //Call some business logic that changes the state of the aggregate root.
        repository[repository.IDof(do)] = do; //Save the domain object with all changes back to the db.
    }

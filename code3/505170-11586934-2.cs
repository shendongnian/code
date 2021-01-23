    public class Person
    {
       // various properties & methods
    
       // constructor access is restricted to control how the class gets consumed
       protected Person() { /* stuff */ }
    
       // Person factory implementation. It's done inside the Person class so that
       // tight control can be kept over constructor access.
       // The factory is what gives you your instances of Person.
       // It has defined inputs and outputs, so you can avoid doing things
       // such as setting properties every time you fetch an instance.
       // The factory takes care of all the object initialization and returns
       // an instance that's ready for use.
       public static Person GetPerson(int id)
       {
           Person p = new Person();
    
           // here you call the repository. It should return either a native
           // data structure like DataReader or DataTable, or a simple DTO class
           // which is then used to populate the properties of Person.
           // the reason for this is to avoid a circular dependency between
           // the repository and Person classes, which will be a compile time error
           // if they're defined in separate libraries
           using(PersonRepository repo = new PersonRepository())
           {
              DataReader dr = repo.GetPerson(id);
              p.FillFromDataReader(dr);
           }
    
           return p;
       }
    
       protected void FillFromDataReader(DataReader dr)
       { /* populate properties in here */ }
    
       // Save should be an instance method, because you need an instance of person
       // in order to save. You don't call the dealership to you drive your car,
       // only when you're getting a new one, so the factory doesn't do the saving.
       // It returns the updated Person, in case you need to populate fields as a
       // result of the save, such as a new database ID, so you have correct data.
       public Person Save()
       {
          // Again, we call the repository here. You can pass a DTO class, or
          // simply pass the necessary properties as parameters
          using(PersonRepository repo = new PersonRepository())
          {
             this.Id = repo.SavePerson(name, address);
          }
       }
    }

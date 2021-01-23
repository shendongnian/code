    // Common scenario.  Entity classes that have a connection to the DB.
    namespace Entities 
    {
       public class Manager
       {
          public virtual int Id { get; set; }
          public virtual User User { get; set; }
          public virtual IList<User> Serfs { get; set; }
       }
    
       public class User
       {
          public virtual int Id { get; set; }
          public virtual string Firstname { get; set; }
          public virtual string Lastname { get; set; }
       }
    }
    // Model class - bit more flattened
    namespace Models 
    {
       public class Manager 
       {
          public int Id { get; set; }
          public string UserFirstname { get; set; }
          public string UserLastname { get; set; }
          public string UserMiddlename { get; set; }
       }
    }

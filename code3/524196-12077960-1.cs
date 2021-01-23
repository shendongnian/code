    public class Person {
      public Person() { }
      public Person(Guid id, string name, string company) {
        this.Uid = id;
        this.Name = name;
        this.Company = company;
      }
    
      public Guid Uid { get; set; }
          
      public string Name { get; set; }
    
      public string Company { get; set; }
    }

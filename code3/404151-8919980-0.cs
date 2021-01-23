    //Structure to hold extra information
    public class PersonDetails
    {
      public string Name {get; private set;}
      public int Age {get; private set;}
      public string Address {get; private set;}
      //Constructor
      public PersonDetails(string name, int age, string address)
      {
        this.Name = name;
        this.Age = age;
        this.Address = address;
      }
    }   

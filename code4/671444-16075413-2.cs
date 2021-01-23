    public class Person
    {
       public int Id { get; set; }
       public string Name { get; set; }
       public int Age { get; set; }
       public int Gender { get; set; }
       public virtual Address Address {get;set;}
       // or possibly, if you want more than one address per person
       public virtual ICollection<Address> Addresses {get;set;}
    }
    
    public class Address
    {
       public int Id { get; set; }
       public string Street { get; set; }
       public int Zip { get; set; }
       public int PersonId {get; set; }
       public virtual Person Person {get;set;}
    }

    public class Teacher 
    {
     public int Id;
     public virtual List<Address> Addresses { get; set; }
    }
    public class Student 
    {
     public int Id;
     public virtual List<Address> Addresses { get; set; }
    }
    public class Address
    {
     public int Id;
    } 

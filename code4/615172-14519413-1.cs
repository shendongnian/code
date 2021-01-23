    public class Employee : IEquatable<Employee>
    {
      public int Id { get; set; }
    
      public bool Equals(Employee other)
      {
        return other.Id == Id;
      } 
    }

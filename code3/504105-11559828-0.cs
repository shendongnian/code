    public class CustomClass : IComparable<CustomClass>
    {
       public string Id { get; set; }        
       public string Name { get; set; }        
       public string CreatedDate get{ get; set; }
       public int CompareTo(CustomClass other)
       {
          return compareDate.CompareTo(other.compareDate);
       }
    }

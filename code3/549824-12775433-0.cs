    public class Employee
    {
       public string Name {get; set; }
       public string Position {get; set; }
       public string NameAndPosition
       {
          return String.Format("{0} - {1}", Name, Position);//
       }
    }

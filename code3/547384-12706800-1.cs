    public class DriverViewModel
    {
       public string FirstName { get; set; }
       public string Surname { get; set; }
       public string FullName
       {
         get {
          return Surname+" "+FirstName; //String.Format("{0} {1}", Surname, FirstName);
         }
       }
    }

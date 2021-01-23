    public class GrantApplicationListViewModel
    {
         public int Id { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
         public string FullName
         {
              get { return FirstName + " " + LastName; }
         }
    
         public DateTime CreatedDate { get; set; }
         public DateTime FormattedDate{ get{ return FormatDate(CreatedDate)}; set; }
    }

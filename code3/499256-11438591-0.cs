    public class UserProfile{
      public int Id { get; set; }
      public string Name { get; set; }
      public string Surname { get; set; }
      public int SexTypeId { get; set; }
      public IEnumerable<SelectListItem> SexTypes { get; set; }
    }

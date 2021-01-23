    public class CreateIssueVM
    {
      [Required]
      public string Name { set;get;}
    
      public List<SelectListItem> Priorities { get; set; }
    
      [Required]
      public int SelectedPriority { set;get;}
    }

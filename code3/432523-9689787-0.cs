    public class RegisterViewModel
    {
         [Display(Name = "Company")]    
         public int? CompanyId { get; set; }
    
         public IEnumerable<SelectListItem> Companies { get; set; }
    }

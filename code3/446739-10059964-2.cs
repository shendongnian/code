    public class RegisterViewModel
    {
     public string FirstName { set;get;} 
     public IEnumerable<SelectListItem> Roles { get; set; }
     public int SelectedRoleId { get; set; }
    }

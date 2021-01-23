    public class MenuViewModel 
    {
      public IEnumerable<SelectListItem> ParentMenuList {get;set;}//a dropDown
      public IEnumerable<SelectListItem> RoleList {get;set;}//a listBox
      public string Name {get;set;}//the menu name //the menu name
      public List<int> SelectedRoles {get;set;}
    }

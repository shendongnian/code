    public class User // in entity DLL
    {
        [Required]
        public string Name {get; set;}
    }
    
    public class UserViewModel : User // in MVC DLL
    {
        public string LastVisitedPage {get; set;} // which only MVC needs to know
    }
    
    Mapper.Map<User, UserViewModel>();
    Mapper.Map<UserViewModel, User>();

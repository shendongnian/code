    public class UserInfoViewModel
    {
        [Required (ErrorMessage="*")]
        public string UserName { get; set; }
    
    
       [Required(ErrorMessage = "*")]
        public string LoginName { get; set; }
    }
    
    // I don't know if you actually need this or not, but your existing model may contain additional properties relevant to the view that I don't know about, so I'll keep it.
    public class ListOfUsersViewModel
    {
        public IList<UserInfoViewModel> UsersOfList { get; set; }
    }

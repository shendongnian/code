    public class ChangeUserNameViewModel
    {
        public ChangeUserNameViewModel()
        {
            var user = User.GetAllButBuiltIn();
            Users = new SelectList(user, "UserName", "UserName");
        }
        public User User
        {
            get;
            set;
        }
        [DisplayName("User Name")]
        public SelectList Users
        {
            get;
            set;
        }
        public string UserName
        {
            get;
            set;
        }
    }

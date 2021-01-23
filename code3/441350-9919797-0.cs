    public class TellAFriendViewModel
    {
        public ICollection<EmailViewModel> Emails { get; set; } // populate 5 of them in ctor or controller
    }
    
    public class EmailViewModel
    {
        public string Email { get; set; }
    }

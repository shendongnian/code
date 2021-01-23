    [Serializable]
    public class SessionUser
    {
        public User User { get; set; }
        public DateTime Expires { get; set; }
    }
    
    [Serializable]
    public class SessionRedirectUrl
    {
        public Uri RedirectUrl { get; set; }
        public DateTime Expires { get; set; }
    }

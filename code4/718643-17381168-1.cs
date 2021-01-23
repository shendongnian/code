    public class LogInModel
    {
        [LocalizedDisplayName("EmailAddress", typeof(AccountMessages))]
        public string Email { get; set; }
        [LocalizedDisplayName("Password", typeof(AccountMessages))]
        public string Password { get; set; }
        [LocalizedDisplayName("RememberMe", typeof(AccountMessages))]
        public bool RememberMe { get; set; }
    }

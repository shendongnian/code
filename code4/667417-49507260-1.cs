    public class ExternalLoginModel : SigninModel
    {
        public override string email { get; set; }
        public string LoginProvider { get; set; }
        public string ProviderKey { get; set; }
    }
    

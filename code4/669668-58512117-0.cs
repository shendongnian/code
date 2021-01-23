    public class CustomCredentials : ClientCredentials
    {
        public CustomCredentials()
        { }
    
        protected CustomCredentials(CustomCredentials cc)
            : base(cc)
        { }
    
        public override System.IdentityModel.Selectors.SecurityTokenManager CreateSecurityTokenManager()
        {
            return new CustomSecurityTokenManager(this);
        }
    
        protected override ClientCredentials CloneCore()
        {
            return new CustomCredentials(this);
        }
    }
    
    public class CustomSecurityTokenManager : ClientCredentialsSecurityTokenManager
    {
        public CustomSecurityTokenManager(CustomCredentials cred)
            : base(cred)
        { }
    
        public override System.IdentityModel.Selectors.SecurityTokenSerializer CreateSecurityTokenSerializer(System.IdentityModel.Selectors.SecurityTokenVersion version)
        {
            return new CustomTokenSerializer(System.ServiceModel.Security.SecurityVersion.WSSecurity11);
        }
    }
    
    public class CustomTokenSerializer : WSSecurityTokenSerializer
    {
        public CustomTokenSerializer(SecurityVersion sv)
            : base(sv)
        { }
    
        protected override void WriteTokenCore(System.Xml.XmlWriter writer,
                                                System.IdentityModel.Tokens.SecurityToken token)
        {
            UserNameSecurityToken userToken = token as UserNameSecurityToken;
    
            string tokennamespace = "o";
    
            DateTime created = DateTime.Now;
            string createdStr = created.ToString("yyyy-MM-ddTHH:mm:ss.fffZ");
    
            // unique Nonce value - encode with SHA-1 for 'randomness'
            // in theory the nonce could just be the GUID by itself
            string phrase = Guid.NewGuid().ToString();
            var nonce = GetSHA1String(phrase);
    
            // in this case password is plain text
            // for digest mode password needs to be encoded as:
            // PasswordAsDigest = Base64(SHA-1(Nonce + Created + Password))
            // and profile needs to change to
            //string password = GetSHA1String(nonce + createdStr + userToken.Password);
    
            string password = userToken.Password;
    
            writer.WriteRaw(string.Format(
            "<{0}:UsernameToken u:Id=\"" + token.Id +
            "\" xmlns:u=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\">" +
            "<{0}:Username>" + userToken.UserName + "</{0}:Username>" +
            "<{0}:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordText\">" +
            password + "</{0}:Password>" +
            "<{0}:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\">" +
            nonce + "</{0}:Nonce>" +
            "<u:Created>" + createdStr + "</u:Created></{0}:UsernameToken>", tokennamespace));
        }
    
        protected string GetSHA1String(string phrase)
        {
            SHA1CryptoServiceProvider sha1Hasher = new SHA1CryptoServiceProvider();
            byte[] hashedDataBytes = sha1Hasher.ComputeHash(Encoding.UTF8.GetBytes(phrase));
            return Convert.ToBase64String(hashedDataBytes);
        }
    
    }

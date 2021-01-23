    [Serializable()]
    [XmlType(AnonymousType = true, Namespace = "urn:www-test-com:testservice")]
    public class AuthenticateUserInput
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Method { get; set; }
    }

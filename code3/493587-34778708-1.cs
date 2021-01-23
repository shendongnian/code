    public class UserRegistrationArguments
    {
        public string nameMiddle { get; set; }
        public string email { get; set; }
    }
    int RegisterUser(string nameFirst, string nameLast, UserRegistrationArguments args = null)

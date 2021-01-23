    public class Admins
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                HashedPassword = HashingMethod(_password);
            }
        }
    }

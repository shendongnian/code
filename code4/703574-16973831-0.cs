    class UserRecord
    {
        public string Name;
        public string Password;
        public string Avatar;
        public UserRecord(string name, string password, string avatar)
        {
            Name = name;
            Password = password;
            Avatar = avatar;
        }
        // static factory method
        public static UserRecord Parse(string source)
        {
            if (string.IsNullOrEmpty(source))
                return null;
            string[] parts = source.Split(',');
            if (parts.Length < 3)
                return null;
            return new UserRecord(parts[0], parts[1], parts[2]);
        }
        // convert to string
        public string ToString()
        {
            return (new string[] { Name, Password, Avatar }).Join(",");
        }
    }

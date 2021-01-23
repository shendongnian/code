    public static class UsersConverter
    {
        // Separates user properties.
        private const char UserDataSeparator = ',';
        // Separates users in the list.
        private const char UsersSeparator = ';';
        public static string ConvertListToString(IEnumerable<User> usersList)
        {
            var stringBuilder = new StringBuilder();
            // Build the users string.
            foreach (User user in usersList)
            {
                stringBuilder.Append(user.Name);
                stringBuilder.Append(UserDataSeparator);
                stringBuilder.Append(user.Age);
                stringBuilder.Append(UsersSeparator);
            }
            // Remove trailing separator.
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            return stringBuilder.ToString();
        }
        public static List<User> ParseStringToList(string usersString)
        {
            // Check that passed argument is not null.
            if (usersString == null) throw new ArgumentNullException("usersString");
            var result = new List<User>();
            string[] userDatas = usersString.Split(UsersSeparator);
            foreach (string[] userData in userDatas.Select(x => x.Split(UserDataSeparator)))
            {
                // Check that user data contains enough arguments.
                if (userData.Length < 2) throw new ArgumentException("Users string contains invalid data.");
                string name = userData[0];
                int age;
                    
                // Try parsing age.
                if (!int.TryParse(userData[1], out age))
                {
                    throw new ArgumentException("Users string contains invalid data.");
                }
                // Add to result list.
                result.Add(new User { Name = name, Age = age });
            }
            return result;
        }
    }

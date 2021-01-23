        public static string GetPassword(string username)
        {
            if (!username.Contains("custom\\")) return String.Empty;
            MijnGazelleEntities container = new CustomEntities();
            Users gebruiker = container.Users.FirstOrDefault(g => g.Email == username.Replace("mijngazelle\\", String.Empty));
            string password = gebruiker != null ? gebruiker.Password : String.Empty;
            container.Connection.Close();
            return password;
        }

    public static string CreateUser(string username, string password)
    {
        using (var sha1 = SHA1.Create())
        {
            var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));
            return string.Format("{0}:{{SHA}}{1}", username, Convert.ToBase64String(hash));
        }
    }

    private static string ComputeHash(string hashedPassword, string message)
    {
        var key = Encoding.UTF8.GetBytes(hashedPassword.ToUpper());
        string hashString;
        using (var hmac = new HMACSHA256(key))
        {
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(message));
            hashString = Convert.ToBase64String(hash);
        }
        return hashString;
    }

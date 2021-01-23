    using System.Security.Cryptography;
    public static string HashSHA1(this string value)
    {
        using (var sha = SHA1.Create())
        {
           return Convert.ToBase64String(sha.ComputeHash(System.Text.Encoding.UTF8.GetBytes(value)));
        }
    }

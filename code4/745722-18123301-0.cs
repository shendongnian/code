    string password = "shortstring";
    using (SHA1 sha = new SHA1CryptoServiceProvider())
    {
        // This is one implementation of the abstract class SHA1.
        byte[] result = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
        Array.Resize(ref result, 16);
    }

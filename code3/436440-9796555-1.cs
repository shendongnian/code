    public bool IsPasswordCorrect(User u, string attempt) 
    {
        var hasher = Hasher.Value;
        var pwBytes = Encoding.Unicode.GetBytes(attempt);
        hasher.TransformBlock(u.Salt, 0, u.Salt.Length, u.Salt, 0);
        hasher.TransformFinalBlock(pwBytes, 0, pwBytes.Length);
        // LINQ method that checks element equality.
        return hasher.Hash.SequenceEqual(u.PasswordHash);  
    }

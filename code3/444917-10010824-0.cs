    public string GenerateToken()
    {
        MD5 md5 = System.Security.Cryptography.MD5.Create();
        DateTime dateTime = DateTime.UtcNow;
        dateTime = dateTime.AddSeconds(-dateTime.Second);
        if (dateTime.Minute % 2 != 0)
            dateTime = dateTime.AddMinutes(1);
    
        byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(dateTime.ToString());
        byte[] hash = md5.ComputeHash(inputBytes);
    
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < hash.Length; i++)
        {
            sb.Append(hash[i].ToString("X2"));
        }
        return sb.ToString();
    }

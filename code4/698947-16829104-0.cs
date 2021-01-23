    using (MD5 a = MD5.Create()) {
        byte[] bytes = Encoding.UTF8.GetBytes(data + salt);
        byte[] hashed = a.ComputeHash(bytes);
        
        var sb = new StringBuilder();        
        for (int i = 0; i < hashed.Length; i++) {
           sb.Append(hashed[i].ToString("x2"));
        }
        Console.WriteLine(sb.ToString()); // a4584f550a133a7f47cc9bafd84c9870
    }

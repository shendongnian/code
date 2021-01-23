    System.Security.Cryptography.SHA1 c = System.Security.Cryptography.SHA1.Create();
    byte[] b = c.ComputeHash(Encoding.UTF8.GetBytes("google.com"));
    byte[] b2 = b.Skip(12).Reverse().ToArray();
    Debug.WriteLine(BitConverter.ToInt64(b2, 0));
    // writes 2172193747348806725

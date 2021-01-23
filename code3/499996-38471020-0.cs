    string result;
    using (MD5 hash = MD5.Create())
    {
        result = String.Join
        (
            "",
            from ba in hash.ComputeHash
            (
                Encoding.UTF8.GetBytes(observedText)
            ) 
            select ba.ToString("x2")
        );
    }

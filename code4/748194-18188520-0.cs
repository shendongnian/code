    int Hash(params int[] values)
    {
        System.Security.Cryptography.MD5 hasher = MD5.Create();
        string valuesAsString = string.Join(",", values);
        var hash = hasher.ComputeHash(Encoding.UTF8.GetBytes(valuesAsString));
        var hashAsInt = BitConverter.ToInt32(hash, 0);
        return Math.Abs(hashAsInt % 1000);
    }

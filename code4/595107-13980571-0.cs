    void Obfuscate(string fileName, string data)
    {
        var bytes = Encoding.UTF8.GetBytes(data);
        for (int i = 0; i < bytes.Length; i++) bytes[i] ^= 0x5a;
        File.WriteAllText(fileName,Convert.ToBase64String(bytes));
    }
    string Deobfuscate(string fileName)
    {
        var bytes = Convert.FromBase64String(File.ReadAllText(fileName));
        for (int i = 0; i < bytes.Length; i++) bytes[i] ^= 0x5a;
        return Encoding.UTF8.GetString(bytes);
    }

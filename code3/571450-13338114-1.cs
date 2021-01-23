    private static readonly AesManaged cipher = new AesManaged()
    {
        BlockSize = 128,
        Key = Encoding.UTF8.GetBytes("secret__secret__"),
        Mode = CipherMode.ECB,
        Padding = PaddingMode.None
    };
    static string Obfuscate(int id)
    {
        using (var transform = cipher.CreateEncryptor())
        {
            return Convert.ToBase64String(
                transform.TransformFinalBlock(
                    Encoding.UTF8.GetBytes(
                        id.ToString("0000000000000000")), 0, 16));
        }
    }
    static int Deobfuscate(string s)
    {
        using (var transform = cipher.CreateDecryptor())
        {
            return int.Parse(
                Encoding.UTF8.GetString(
                    transform.TransformFinalBlock(
                        Convert.FromBase64String(s), 0, 16)));
        }
    }

private string GenerateRandomId(int length)
{
    char[] stringChars = new char[length];
    byte[] randomBytes = new byte[length];
    using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
    {
        rng.GetBytes(randomBytes);
    }
    string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";           
    for (int i = 0; i < stringChars.Length; i++)
    {
        stringChars[i] = chars[randomBytes[i] % chars.Length];
    }
    return new string(stringChars);
}

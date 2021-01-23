    private static string GetStringFromAsciiHex(String input)
    {
        if (input.Length % 2 != 0)
            throw new ArgumentException("input");
        byte[] bytes = new byte[input.Length / 2];
        for (int i = 0; i < input.Length; i += 2)
        {
            // Split the string into two-bytes strings which represent a hexadecimal value, and convert each value to a byte
            String hex = input.Substring(i, 2);
            bytes[i/2] = Convert.ToByte(hex, 16);                
        }
        return System.Text.ASCIIEncoding.ASCII.GetString(bytes);
    }

    string input = "0x37, 0x32, 0x2d, 0x38, 0x33, 0x39, 0x37, 0x32, 0x2d, 0x30, 0x31";
    string[] bytes = input.Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
    byte[] values = new byte[bytes.Length];
    for (int i = 0; i < bytes.Length; i++)
    {
        values[i] = byte.Parse(bytes[i].Substring(2,2), System.Globalization.NumberStyles.AllowHexSpecifier);
        Console.WriteLine(string.Format("{0}", values[i]));
    }

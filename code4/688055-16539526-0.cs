    string s1 = "Stack Overflow :)";
    byte[] bytes = new byte[s1.Length];
    for (int i = 0; i < s1.Length; i++)
    {
          bytes[i] = Convert.ToByte(s1[i]);
    }
    List<string> hexStrings = new List<string>();
    foreach (byte b in bytes)
    {
         hexStrings.Add(Convert.ToInt32(b).ToString("X"));
    }

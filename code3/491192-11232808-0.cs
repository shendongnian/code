    ushort t = 344;
    byte[] bytes = BitConverter.GetBytes(t);
    string hex = BitConverter.ToString(bytes);
    hex = hex.Replace("-", "");
    p.WriteString(hex);

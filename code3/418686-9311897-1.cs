    System.Text.Encoding ascii = System.Text.Encoding.ASCII;
    string str = "xyz";
    Byte[] encodedBytes = ascii.GetBytes(str);
    foreach (Byte b in encodedBytes)
    {
       return b;
    }

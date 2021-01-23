    public static byte[] ConvertToBinary(string str)
    {
    System.Text.ASCIIEncoding  encoding = new System.Text.ASCIIEncoding();
    return encoding.GetBytes(str);
    }
       or
    Convert.ToByte(string);

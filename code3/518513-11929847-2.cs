    // C# to convert a string to a byte array.
    public static byte[] StrToByteArray(string str)
    {
        Encoding encoding = Encoding.UTF8; //or below line
        //System.Text.UTF8Encoding  encoding=new System.Text.UTF8Encoding();
        return encoding.GetBytes(str);
    }

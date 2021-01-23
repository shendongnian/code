    public static string ByteArrayToString(byte[] ba)
    {
       string hex = BitConverter.ToString(ba);
       return hex.Replace("-","");
    }
    int i = 39;
    string str = "ssifm";
    long l = 93823;
    string hexi = ByteArrayToString(BitConverter.GetBytes(i));
    string hexstr = ByteArrayToString(Encoding.Ascii.GetBytes(str));
    string hexl = ByteArrayToString(BitConverter.GetBytes(l));

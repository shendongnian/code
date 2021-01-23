    public static string Convert(string raw)
    {
    	return raw.Substring(0,6)+"-"+raw.Substring(6,2);
    }
    Console.WriteLine (Convert("00000201001"));
    //output= 000002-01

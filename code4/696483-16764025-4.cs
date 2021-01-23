    public static decimal GetMilliSeconds(byte[] ntpTime)
    {
        decimal intpart = 0, fractpart = 0;
        for (var i = 0; i <= 3; i++)
            intpart = 256 * intpart + ntpTime[i];
        for (var i = 4; i <= 7; i++)
            fractpart = 256 * fractpart + ntpTime[i];
        var milliseconds = intpart * 1000 + ((fractpart * 1000) / 0x100000000L);
        Console.WriteLine("milliseconds: " + milliseconds);
        Console.WriteLine("intpart:      " + intpart);
        Console.WriteLine("fractpart:    " + fractpart);
        return milliseconds;
    }
    public static byte[] ConvertToNtp(decimal milliseconds)
    {
        decimal intpart = 0, fractpart = 0;
        var ntpData = new byte[8];
        intpart = milliseconds / 1000;
        fractpart = ((milliseconds % 1000) * 0x100000000L) / 1000m;
        Console.WriteLine("milliseconds: " + milliseconds);
        Console.WriteLine("intpart:      " + intpart);
        Console.WriteLine("fractpart:    " + fractpart);
        var temp = intpart;
        for (var i = 3; i >= 0; i--)
        {
            ntpData[i] = (byte)(temp % 256);
            temp = temp / 256;
        }
        temp = fractpart;
        for (var i = 7; i >= 4; i--)
        {
            ntpData[i] = (byte)(temp % 256);
            temp = temp / 256;
        }
        return ntpData;
    }
    public static void Main(string[] args)
    {
        byte[] bytes = { 131, 170, 126, 128,
               46, 197, 205, 234 };
        var ms = GetMilliSeconds(bytes);
        Console.WriteLine();
        var ntp = ConvertToNtp(ms);
    }

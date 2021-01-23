    static void Main(string[] args)
    {
        bool Worked = false;
        string Password = "testing";
        Console.WriteLine("Password: " + Password);
        // == Encode then decode 64 test. DecPass64 should equal password == //
        // Encodes to Base64 using ToBase64Transform
        string EncPass64 = Base64Helper.EncodeString(Password);
        // Decodes a Base64 string using FromBase64Transform
        string DecPass64 = Base64Helper.DecodeString(EncPass64);
        // Test if base 64 ecoding / decoding works
        Worked = (Password == DecPass64);
        Console.WriteLine();
        Console.WriteLine("Base64 Pass Encoded: " + EncPass64);
        Console.WriteLine("Base64 Pass Decoded: " + DecPass64);
        Console.WriteLine("Base64 Encode to Base64 Decode Worked? : " + Worked); // True
        // gspassenc uses XOR to switch passwords back and forth between encrypted and decrypted
        byte [] passwordbytes = Encoding.UTF8.GetBytes(Password);
        byte [] bytes_GsEncodedPass = gspassenc(passwordbytes);
        string GsEncodedPass = Encoding.UTF8.GetString(bytes_GsEncodedPass);
        byte[] bytes_GsDecodedPass = gspassenc(bytes_GsEncodedPass);
        string GsDecodedPass = Encoding.UTF8.GetString(bytes_GsDecodedPass);
        Worked = (Password == GsDecodedPass);
        // GsDecodedPass should equal the original Password
        Console.WriteLine();
        Console.WriteLine("GsPass Encoded: " + GsEncodedPass);
        Console.WriteLine("GsPass Decoded: " + GsDecodedPass);
        Console.WriteLine("GsEncode to GsDecode Worked? : " + Worked); // True
        // Bas64 encode the encrypted password. Then decode the base64. B64_GsDecodedPass should equal
        // the GsEncoded Password... But it doesn't for some reason!
        string B64_GsEncodedPass = Convert.ToBase64String(bytes_GsEncodedPass);
        byte []bytes_B64_GsDecodedPass = Convert.FromBase64String(B64_GsEncodedPass);
        string B64_GsDecodedPass = Encoding.UTF8.GetString(bytes_B64_GsDecodedPass);
        Worked = (B64_GsDecodedPass == GsEncodedPass);
        // Print results
        Console.WriteLine();
        Console.WriteLine("Base64 Encoded GsPass: " + B64_GsEncodedPass);
        Console.WriteLine("Base64 Decoded GsPass: " + B64_GsDecodedPass);
        Console.WriteLine("Decoded == GS Encoded Pass? : " + Worked); // False
        // Stop console from closing till we say so
        Console.Read();
    }
    private static int gslame(int num)
    {
        int c = (num >> 16) & 0xffff;
        int a = num & 0xffff;
        c *= 0x41a7;
        a *= 0x41a7;
        a += ((c & 0x7fff) << 16);
        if (a < 0)
        {
            a &= 0x7fffffff;
            a++;
        }
        a += (c >> 15);
        if (a < 0)
        {
            a &= 0x7fffffff;
            a++;
        }
        return a;
    }
    private static byte[] gspassenc(byte [] pass)
    {
        int a = 0;
        int num = 0x79707367; // gspy
        int len = pass.Length;
        byte[] newPass = new byte[len];
        for (int i = 0; i < len; ++i)
        {
            num = gslame(num);
            a = num % 0xFF;
            newPass[i] = (byte)(pass[i] ^ a);
        }
        return newPass;
    }

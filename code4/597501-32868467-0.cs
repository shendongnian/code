    // Important note: when parsing hexadecimal string, make sure to prefix
    // with 0 if the digits number is odd. Ex: 0F instead of F, and 01A3 instead of
    // 1A3. For some reason, BigInteger interprets them differently.
    
    var x = BigInteger.Parse("0F", NumberStyles.HexNumber); // Or: BigInteger.Parse("15")
    
    var biBytes = x.ToByteArray();
    
    var bits = new bool [8 * biBytes.Length];
    
    new BitArray(x.ToByteArray()).CopyTo(bits, 0);
    
    bits = bits.Reverse().ToArray(); // BigInteger uses little endian when extracting bytes (thus bits), so we inverse them.
    
    var builder = new StringBuilder();
    
    foreach(var bit in bits)
    {
        builder.Append(bit ? '1' : '0');
    }
    
    string final = Regex.Replace(builder.ToString(), @"^0+", ""); // Because bytes consume full 8 bits, we might occasionally get leading zeros.
    
    Console.WriteLine(final);

    static void Main()
    {
        byte[] theByte = new[]{(byte)129};
    
        string asciiString = Encoding.ASCII.GetString(theByte);
    
        byte[] decodedBytes = Encoding.ASCII.GetBytes(asciiString);
    
        Console.WriteLine(theByte[0]);
        Console.WriteLine(asciiString);
        Console.WriteLine(decodedBytes[0]);
    
        Console.ReadLine();
    }

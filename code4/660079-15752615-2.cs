    static void Main()
    {
        byte[] bytes = new[]{(byte)129};
    
        string asciiString = Encoding.ASCII.GetString(bytes);
    
        byte[] encodedBytes = Encoding.ASCII.GetBytes(asciiString);
    
        Console.WriteLine(bytes[0]);
        Console.WriteLine(asciiString);
        Console.WriteLine(encodedBytes[0]);
    
        Console.ReadLine();
    }

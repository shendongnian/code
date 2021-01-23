    static void Main(string[] args)
    {
        int buff;  // string to int
        SerialPort port = new SerialPort("COM4", 9600, Parity.None, 8, StopBits.One);
        port.Open();
        for (int i = 0; i < 2000; i++)
        {
            Console.ReadLine();  // wait for the Enter key
            buff = port.ReadByte();  // read a byte
            Console.WriteLine(buff);
        }
    }

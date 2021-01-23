    [StructLayout(LayoutKind.Explicit)]
    struct IPv4Address
    {
        [FieldOffset(0)]
        public uint Address;
        [FieldOffset(0)]
        public byte b3;
        [FieldOffset(1)]
        public byte b2;
        [FieldOffset(2)]
        public byte b1;
        [FieldOffset(3)]
        public byte b0;
    }
    class MainClass
    {
        public static void Main(string[] args)
        {
            IPv4Address myAddress;
            // Assign localhost to the IPv4 address
            myAddress.Address = 0; // Avoid CS0170: Unassigned Field error
            myAddress.b0 = 127;
            myAddress.b1 = 0;
            myAddress.b2 = 0;
            myAddress.b3 = 1;
            Console.WriteLine("The address in hexadecimal: {0:x}",myAddress.Address);
        }
    }
}

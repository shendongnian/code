    const byte B_0 = 0x0;
    const byte B_1 = 0x1;
    const byte B_F = 0xF;
    
    static void Main()
    {
        byte[] registers = new byte[16];
        registers[0x1] = 255;
        registers[0x2] = 127;
        Opcode8XY5(registers, 1, 2);
        Console.WriteLine(registers[0x1]);
        Console.WriteLine(registers[0x2]);
        Console.WriteLine(registers[0xF]);
        Opcode8XY7(registers, 1, 2);
        Console.WriteLine(registers[0x1]);
        Console.WriteLine(registers[0x2]);
        Console.WriteLine(registers[0xF]);
        Console.ReadLine();
    }
    
    static void Opcode8XY5(byte[] registers, byte x, byte y)
    {
        registers[B_F] = registers[x] >= registers[y] ? B_1 : B_0;
        registers[x] = (byte)(registers[x] - registers[y]);
    }
    
    static void Opcode8XY7(byte[] registers, byte x, byte y)
    {
        registers[B_F] = registers[y] >= registers[x] ? B_1 : B_0;
        registers[x] = (byte)(registers[y] - registers[x]);
    }

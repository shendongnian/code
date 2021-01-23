    unsafe
    {
        var u = new UnionPacket();
        for (byte i = 0; i < 12; i++)
        {
             u.data[i] = i;
        }
        Console.WriteLine(u.Time);
        Console.WriteLine(u.CoordX);
        Console.WriteLine(u.CoordY);        
        Console.WriteLine(u.Red);
        Console.WriteLine(u.Green);
        Console.WriteLine(u.Blue);
        Console.WriteLine(u.Alpha);
    }

    byte[] value = new byte[8];
    Array.Reverse(srno); // otherwise you will have a1612240fff result
    Array.Copy(srno, value, 6);
    ulong result = BitConverter.ToUInt64(value, 0);
    Console.WriteLine("{0:x}", result); // ff0f2412160a

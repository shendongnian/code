    // note these should really use "using" statements of similar
    FileStream stream = new FileStream("test", FileMode.Create);
    BufferedStream buff = new BufferedStream(stream, 8);
    BinaryWriter writer = new BinaryWriter(buff);
    writer.Write(1);
    writer.Write(2);
    writer.Write(3);
    Console.WriteLine(stream.Length); // 8
    Console.WriteLine(buff.Length); // 12

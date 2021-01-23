    using (var s = new NamedPipeClientStream ("myPipe"))
    {
     s.Connect();
     Console.WriteLine (s.ReadByte());
     s.WriteByte (200);  
    }

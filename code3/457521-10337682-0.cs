    var broadcast = new BroadcastBlock<byte[]>(x => x);
    
    var strategy1 = new ActionBlock<byte[]>(input => ProcessUsingStrategy1(input));
    var strategy2 = new ActionBlock<byte[]>(input => ProcessUsingStrategy2(input));
    // Create the other 4 strategies.
    
    broadcast.LinkTo(strategy1);
    broadcast.LinkTo(strategy2);
    // Link the other 4.
    
    using (var fs = File.Open(@"yourfile.txt", FileMode.Open, FileAccess.Read))
    using (var br = new BinaryReader(fs))
    {
      while (br.PeekChar() != -1)
      {
        broadcast.Post(br.ReadBytes(1024 * 16));
      }
    }

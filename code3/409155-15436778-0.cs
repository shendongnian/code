    // the time series item type
    struct Tick
    {
        public DateTime Time;
        public double Price;
        public int Volume;
    }
    // create file and write some values
    var ms = new MemoryStream();
    using (var tf = TeaFile<Tick>.Create(ms))
    {
        tf.Write(new Tick { Price = 5, Time = DateTime.Now, Volume = 700 });
        tf.Write(new Tick { Price = 15, Time = DateTime.Now.AddHours(1), Volume = 1700 });
        // ...
    }
    ms.Position = 0; // reset the stream
    // read typed
    using (var tf = TeaFile<Tick>.OpenRead(ms))
    {
        Tick value = tf.Read();
        Console.WriteLine(value);
    }

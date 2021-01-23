    static void Main(string[] args)
    {
        //Create your data
        var rnd = new Random();
        //var data = Enumerable.Range(0, 10).ToArray();
        var data = Enumerable.Range(0, 10).Select(x => rnd.Next(1 << 13)).ToArray();
    
        var bits = new BitSerlializer();
    
        //Add length header
        bits.AddInt(data.Length, 8);
        foreach (var n in data)
        {
            bits.AddInt(n, 13);
            Console.WriteLine(n);
        }
    
        //Serialize to bytes for network transfer etc.
        var bytes = bits.ToBytes();
    
        Console.WriteLine(new string('-', 13));
    
        //Deserialize
        bits = new BitSerlializer(bytes);
        //Get Length Header
        var count = bits.ReadInt(8);
    
        for (int i = 0; i < count; i++)
            Console.WriteLine(bits.ReadInt(13));
    
        Console.ReadLine();
    }
    
    public class BitSerlializer
    {
        List<byte> bytes;
        int Position { get; set; }
    
        public BitSerlializer(byte[] initialData = null)
        {
            if (initialData == null)
                bytes = new List<byte>();
            else
                bytes = new List<byte>(initialData);
        }
    
        public byte[] ToBytes() { return bytes.ToArray(); }
    
        public void Addbit(bool val)
        {
            if (Position % 8 == 0) bytes.Add(0);
            if (val) bytes[Position / 8] += (byte)(1 << (Position % 8));
            Position++;
        }
        public void AddInt(int i, int bits)
        {
            for (int pos = bits; pos >= 0; pos--)
                Addbit((i & (1 << pos)) != 0);
        }
    
        public bool ReadBit()
        {
            var val = (bytes[Position / 8] & (1 << (Position % 8))) != 0;
            ++Position;
            return val;
        }
    
        public int ReadInt(int bits)
        {
            var val = 0;
            for (int pos = bits; pos >= 0; pos--)
                if (ReadBit())
                    val += 1 << pos;
            return val;
        }
    }

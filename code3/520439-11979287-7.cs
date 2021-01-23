    //Improved to take sign into account.
    //Sign is in addition to bits allocated for storage in this version.
    //Stored as {sign}{bits}
    //E.g.  -5, stored in 3 bits signed is:
    //       1 101
    //E.g.   5, stored in 3 bits [with sign turned on]
    //       0 101
    //E.g.   5, stored in 3 bits no sign
    //         101  
    //This may differ from your exiting format - e.g. you may use two's compliments.
    static void Main(string[] args)
    {
        int bitsPerInt = 13;
    
        //Create your data
        var rnd = new Random();
        //var data = Enumerable.Range(-5, 10).ToArray();
        var data = Enumerable.Range(0, 10).Select(x => rnd.Next(-(1 << bitsPerInt), 1 << bitsPerInt)).ToArray();
    
        var bits = new BitSerlializer();
    
        //Add length header
        bits.AddInt(data.Length, 8, false);
        foreach (var n in data)
        {
            bits.AddInt(n, bitsPerInt);
            Console.WriteLine(n);
        }
    
        //Serialize to bytes for network transfer etc.
        var bytes = bits.ToBytes();
    
        Console.WriteLine(new string('-', 10));
        foreach (var b in bytes) Console.WriteLine(Convert.ToString(b, 2).PadLeft(8, '0'));
        Console.WriteLine(new string('-', 10));
    
        //Deserialize
        bits = new BitSerlializer(bytes);
        //Get Length Header
        var count = bits.ReadInt(8, false);
        for (int i = 0; i < count; i++)
            Console.WriteLine(bits.ReadInt(bitsPerInt));
    
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
            if (val) bytes[Position / 8] += (byte)(128 >> (Position % 8));
            Position++;
        }
    
        public void AddInt(int i, int length, bool isSigned = true)
        {
            if (isSigned) Addbit(i < 0);
            if (i < 0) i = -i;
    
            for (int pos = --length; pos >= 0; pos--)
            {
                var val = (i & (1 << pos)) != 0;
                Addbit(val);
            }
        }
    
        public bool ReadBit()
        {
            var val = (bytes[Position / 8] & (128 >> (Position % 8))) != 0;
            ++Position;
            return val;
        }
    
        public int ReadInt(int length, bool isSigned = true)
        {
            var val = 0;
            var sign = isSigned && ReadBit() ? -1 : 1;
    
            for (int pos = --length; pos >= 0; pos--)
                if (ReadBit())
                    val += 1 << pos;
    
            return val * sign;
        }
    }

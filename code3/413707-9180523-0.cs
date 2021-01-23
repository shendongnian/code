    class Program
    {
        static void Main(string[] args)
        {
            var pack = new Packet<int>() { Payload = 13 };
            var serializedData = pack.Serialize();
            var deserializedData = Packet.Deserialize(serializedData);
            Console.WriteLine("The payload type is:" + deserializedData.PayloadType.Name);
            Console.WriteLine("the payload is: " + deserializedData.Payload);
            Console.ReadLine();
        }
    }
    
    [Serializable]
    public class Packet
    {
        public Type PayloadType { get; protected set; }
        public object Payload { get; protected set; }
        public static Packet Deserialize(byte[] bytes)
        {
            return (Packet)(new BinaryFormatter()).Deserialize(new MemoryStream(bytes));
        }
    }
    [Serializable]
    class Packet<T> : Packet
    {
        public Packet()
        {
            PayloadType = typeof(T);
        }
        public new T Payload 
        {
            get { return (T)base.Payload; } 
            set { base.Payload = value; } 
        }
        public override string ToString()
        {
            return "[Packet]" + Payload.ToString();
        }
        public byte[] Serialize()
        {
            MemoryStream m = new MemoryStream();
            (new BinaryFormatter()).Serialize(m, this);
            return m.ToArray();
        }
    }

        public static List<Packet> Packets = new List<Packet>();
        public class Packet
        {
            public Packet(string Name)
            {
                Packets.Add(this);
                name = Name;
            }
            internal string _name;
            public string name
            {
                get { return _name; }
                set { _name = value; }
            }
        }

    public struct PByte : IEquatable<PByte>
    {
        readonly byte _value;
        public PByte(byte value)
        {
            this._value = (byte)( value > 31 && value < 128 ? value : 0);
        }
        public byte Value { get { return this._value; } }
        public char Char { get { return (char)_value; } }
        public bool Equals(PByte other)
        {
            return _value.Equals(other._value);
        }        
    }
    class Program
    {
        static void Main(string[] args)
        {
            var p1 = new PByte(1000); // Won't compile
            var p2 = new PByte(5);      //'\0'
            var p3 = new PByte(65);     //'A'
            var p4 = new PByte(125);    //'}'
            var p5 = new PByte(175);    //'\0'
        }
    }

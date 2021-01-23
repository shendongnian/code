    [StructLayout(LayoutKind.Explicit)]
    public struct Variant
    {
        [FieldOffset(0)]
        public int Integer;
        [FieldOffset(0)]
        public float Float;
        [FieldOffset(0)]
        public double Double;
        [FieldOffset(0)]
        public byte Byte;
        // etc
    }
    // Check if it works - shouldn't print 0.
    public class VariantTest
    {
        static void Main(string[] args)
        {
            Variant v = new Variant() { Integer = 2 };
            Console.WriteLine("{0}", v.Float);
            Console.ReadLine();
        }
    }

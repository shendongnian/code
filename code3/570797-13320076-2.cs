    public enum LO { SIZE = 3}
    [StructLayout(LayoutKind.Explicit, Size = (int)LO.SIZE)]
    public struct Test
    {
        [FieldOffset(0)]
        public char c1;
        [FieldOffset(1)]
        public char c2;
        [FieldOffset(2)]
        public char c3;
    }
    class Program
    {
        static void Main()
        {
            Test t = new Test() {c1 = '1', c2 = '2', c3 = '3'};
            using (MemoryMappedFile file = MemoryMappedFile.CreateNew(null, 1))
            using (MemoryMappedViewAccessor accessor = file.CreateViewAccessor())
            {
                accessor.Write<Test>(0L, ref t);
                t = new Test() { c1 = 'a', c2 = 'b', c3 = 'c' };
                accessor.Write<Test>((long)LO.SIZE, ref t);
                using (StreamReader sr = new StreamReader(file.CreateViewStream(), ASCIIEncoding.ASCII))
                {
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
        }
    }

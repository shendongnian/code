    [StructLayout(LayoutKind.Explicit, Size = 9)]
    public struct Test
    {
        [FieldOffset(0)]
        public DateTime dt1;
        [FieldOffset(8)]
        public byte b;
    }
    class Program
    {
        static readonly Func<Type, uint> SizeOfType = (Func<Type, uint>)Delegate.CreateDelegate(typeof(Func<Type, uint>), typeof(Marshal).GetMethod("SizeOfType", BindingFlags.NonPublic | BindingFlags.Static));
        static void Main()
        {
            Test t = new Test() { dt1 = DateTime.MaxValue, b = 42 };
            Console.WriteLine("Managed size: " + SizeOfType(typeof(Test)));
            Console.WriteLine("Unmanaged size: " + Marshal.SizeOf(t));
            using (MemoryMappedFile file = MemoryMappedFile.CreateNew(null, 1))
            using (MemoryMappedViewAccessor accessor = file.CreateViewAccessor())
            {
                accessor.Write(0L, ref t);
                long pos = 0;
                for (int i = 0; i < 9; i++)
                    Console.Write("|" + accessor.ReadByte(pos++));
                Console.Write("|\n");
            }
        }
    }

    namespace MemoryAllocation
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (MemAllocLib.ChunkAllocator chunk = new MemAllocLib.ChunkAllocator())
                {
                    Console.WriteLine(">> Simple data test");
                    SimpleDataTest(chunk);
                    Console.WriteLine();
                    Console.WriteLine(">> Complex data test");
                    ComplexDataTest(chunk);
                }
                Console.ReadLine();
            }
            private static void SimpleDataTest(MemAllocLib.ChunkAllocator chunk)
            {
                IntPtr ptr = chunk.Allocate<System.Int32>();
                Console.WriteLine(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Int32>(ptr));
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Int32>(ptr) == 0, "Data not initialized properly");
                System.Diagnostics.Debug.Assert(chunk.AllocatedMemory == sizeof(Int32), "Data not allocated properly");
                int data = MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Int32>(ptr);
                data = 10;
                MemAllocLib.ChunkAllocator.StoreStructure(ptr, data);
                Console.WriteLine(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Int32>(ptr));
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Int32>(ptr) == 10, "Data not set properly");
                Console.WriteLine("All tests passed");
            }
            private static void ComplexDataTest(MemAllocLib.ChunkAllocator chunk)
            {
                IntPtr ptr = chunk.Allocate<Person>();
                Console.WriteLine(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr));
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr).Age == 0, "Data age not initialized properly");
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr).Name == null, "Data name not initialized properly");
                System.Diagnostics.Debug.Assert(chunk.AllocatedMemory == System.Runtime.InteropServices.Marshal.SizeOf(typeof(Person)) + sizeof(Int32), "Data not allocated properly");
                Person data = MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr);
                data.Name = "Bob";
                data.Age = 20;
                MemAllocLib.ChunkAllocator.StoreStructure(ptr, data);
                Console.WriteLine(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr));
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr).Age == 20, "Data age not set properly");
                System.Diagnostics.Debug.Assert(MemAllocLib.ChunkAllocator.ConvertPointerToStruct<Person>(ptr).Name == "Bob", "Data name not set properly");
                Console.WriteLine("All tests passed");
            }
            struct Person
            {
                public string Name;
                public int Age;
                public Person(string name, int age)
                {
                    Name = name;
                    Age = age;
                }
                public override string ToString()
                {
                    if (string.IsNullOrWhiteSpace(Name))
                        return "Age is " + Age;
                    return Name + " is " + Age + " years old";
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashSetComposite hsc1 = new HashSetComposite();
            HashSetComposite hsc2 = new HashSetComposite();
            for (UInt16 i = 0; i < 100; i++)
            {
                for (UInt16 j = 0; j < 40000; j++)
                {
                    hsc1.Add(i, j);
                }
                for (UInt16 j = 20000; j < 60000; j++)
                {
                    hsc2.Add(i, j);
                }
            }
            Console.WriteLine(hsc1.Intersect(hsc2).Count().ToString());
            Console.WriteLine(hsc1.Union(hsc2).Count().ToString());
        }
    }
    
    public class HashSetComposite : HashSet<UInt32>
    {
        public void Add(UInt16 u1, UInt16 u2)
        {      
            UInt32 unsignedKey = (((UInt32)u1) << 16) | u2;
            Add(unsignedKey);           
        }
        //left over notes from long
        //ulong unsignedKey = (long) key;
        //uint lowBits = (uint) (unsignedKey & 0xffffffffUL);
        //uint highBits = (uint) (unsignedKey >> 32);
        //int i1 = (int) highBits;
        //int i2 = (int) lowBits;
    }

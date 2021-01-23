    using System;
    
    public class Test
    {
        static void Main()
        {
            ShowHash("PARAM.SFO");
            ShowHash("RAGE.SAV");
        }
            
        static void ShowHash(string name)
        {
            uint hash = 0;
            foreach (char c in name)
            {
                hash = (hash << 5) - hash + (byte) c;
            }
            Console.WriteLine("0x{0:X} mod 0x39 = {1:X}", hash, hash % 0x39);
        }
    }

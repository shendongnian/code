    class Program
        {
            static void Main(string[] args)
            {
                Class2 c2 = new Class2("X"); //outputs '10' once it's instantiated
    
                Console.ReadKey();
            }
        }
    
        class Class2
        {
            //overloaded ctor
            public Class2(string rom)
            {
                Console.WriteLine(RomToNum(rom));
            }
            public static int RomToNum(String rom)
            {
                StringBuilder temp = new StringBuilder();
                int ret = 0;
                char[] letters = rom.ToArray();
                foreach (char item in letters)
                {
                    if (item == 'M')
                        ret += 1000;
                    if (item == 'D')
                        ret += 500;
                    if (item == 'C')
                        ret += 100;
                    if (item == 'L')
                        ret += 50;
                    if (item == 'X')
                        ret += 10;
                }
    
                for (int x = 0; x < letters.Length; x++)
                {
                    if (letters[x] == 'I' && !letters.Contains('V'))
                    {
                        ret += 1;
                    }
                    else
                    {
                        if (letters[x] == 'I' && x != letters.Length - 1)
                        {
                            ret += 4;
                            break;
                        }
                        else if (letters[x] == 'I' && x == letters.Length - 1)
                        {
                            ret += 6;
                            break;
                        }
                    }
                }
                return ret;
    
            }
        }

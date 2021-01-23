    using System;
    namespace Demo
    {
        class Program
        {
            void Run()
            {
                string input = "12345678901234";
                string output = reorder(input);
                Console.WriteLine(output);
            }
            string reorder(string input)
            {
                var a = input.ToCharArray();
                for (int i = 0; i < a.Length/2; i += 2)
                {
                    swap(ref a[i], ref a[a.Length-2-i]);
                    swap(ref a[i+1], ref a[a.Length-1-i]);
                }
                return new string(a);
            }
            void swap(ref char a, ref char b)
            {
                char t = a;
                a = b;
                b = t;
            }
            static void Main()
            {
                new Program().Run();
            }
        }
    }

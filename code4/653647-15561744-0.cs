        static void Main(string[] args)
        {
            
            int i = 1;
            foo(i);
            Console.Write(i); //i=1;
            Reffoo(ref i);
            Console.Write(i); //i=2;
        }
        static void Reffoo(ref int i)
        {
            i++;
        }
        static void foo(int i)
        {
            i++;
        }

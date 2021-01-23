    static void increment (ref int num)//num is passed by ref now
        {
            num++;
        }
            static void Main (string[] args)
        {   
            int x=30;
    
            Console.WriteLine(x);
            increment(ref x);
            Console.WriteLine(x);
        }

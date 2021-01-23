    class Program
    {
        static bool M(out int x) 
        { 
            x = 123; 
            return true; 
        }
        static int N(dynamic d)
        {
            int y;
            if(d || M(out y))
                y = 10;
            return y; 
        }
    }

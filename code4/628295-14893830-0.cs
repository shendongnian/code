    class Program
    {
       
            public int add(int a, float b)
            {
                return a + Convert.ToInt32(b);
            }
            public int add(float a, int b)
            {
                return Convert.ToInt32(a) + b;
            }
        
        static void Main(string[] args)
        {
            Program pr = new Program();
           int k= pr.add(12, 203.9f);
           int kk = pr.add(203.9f, 12);
           Console.WriteLine(k);
           Console.WriteLine(kk);
        }
    }

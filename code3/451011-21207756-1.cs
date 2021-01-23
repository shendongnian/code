    namespace Add_Function
    {
      class Program
      {
        public static void(string[] args)
        {
           int a;
           int b;
           int c;
           Console.WriteLine("Enter value of 'a':");
           a = Convert.ToInt32(Console.ReadLine());
           Console.WriteLine("Enter value of 'b':");
           b = Convert.ToInt32(Console.ReadLine());
           //why can't I not use it this way?
           c = Add(a, b);
           Console.WriteLine("a + b = {0}", c);
        }
        public static int Add(int x, int y)
        {
            int result = x + y;
            return result;
         }
      }
    }

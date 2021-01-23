     class Program
    {
        // i am going to add and subtract two num but i wanna get result in string the same thing you can do for int and what ever you want
          delegate string mydeledagte(int a,int b);
          delegate string d(int s, int t);
        static void Main(string[] args)
        {
            mydeledagte ab = new mydeledagte(ad);
            mydeledagte d= new mydeledagte(sub);
            mydeledagte multi = ab + d;
           
            foreach (mydeledagte individualMI in multi.GetInvocationList())
            {
                string retVal = individualMI(3, 5);
                Console.WriteLine("Output: " + retVal);
                Console.WriteLine("\n***developer of KUST***");
                Console.ReadKey();
            }
        }
        static string ad(int a, int b)
        {
            
            return (a + b).ToString();
           
        }
        static string sub(int a, int b)
        {
            return (a - b).ToString(); ;
        }
    }

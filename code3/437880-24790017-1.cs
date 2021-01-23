    namespace Algorithms
    {
        class Program
        {
            static void Main(string[] args)
            {
                string fibResult = "";
                fibResult =  FibCal(10);
                Console.WriteLine(fibResult);
                Console.ReadLine();
            }
    
            public static string FibCal(int n)
            {
                string series = "";
                int k, f1, f2 , f = 0;
                f1 = f2 = 1;
                if (n < 2) 
                    return n.ToString();
                else
                    for (k = 0; k < n; k++)
                    {
                        f = f1 + f2;
                        f2 = f1;
                        f1 = f;
                        series += f.ToString() + ",";
                    }
    
                return series;
            }
    
        }
    }

    namespace _02__Part_A_
    {
        class Program
        {
            float res = 1;
            public float func3(int n,int a) {
                if (n == 0)
                    return 1/(a*res);
                res = res * (a + n);
                n--;
                return func3(n,a);
            }
            static void Main(string[] args)
            {
                Program a = new Program();
                float resOFfunc3 = (float)0.5;
                string n = Console.ReadLine();
                string ak = Console.ReadLine();
                for (int nn = int.Parse(n); nn > 0; nn--)
                {
                    res = 1;   // Need to add this
                    resOFfunc3 += a.func3(nn, int.Parse(ak));
                }
                Console.WriteLine(resOFfunc3.ToString());
            }
        }
    }

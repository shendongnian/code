    class C
    {
        int n;
        void M()
        {
            {
              Console.WriteLine(n); // n means this.n
            }
            Func<double, double> f = n=>n; // n means the formal parameter
        }
    }

        static Random rnd=new Random();
        static void Main(string[] args)
        {
            double W=12;
            double M=1.0;
            int N=7;
            double S=W-(N-1)*M;
            double[] T=new double[N];
            
            for(int i=0; i<N; i++)
            {
                T[i]=rnd.NextDouble()*S;
            }
            Array.Sort(T);
            for(int i=0; i<N; i++)
            {
                T[i]+=M*i;
            }
            Console.WriteLine("{0,8} {1,8}", "#", "Time");
            for(int i=0; i<N; i++)
            {
                Console.WriteLine("{0,8} {1,8:F3}", i+1, T[i]);    
            }
            // With N=3, Window 12h, Min. Span = 5h
            //      #     Time
            //      1    0.468
            //      2    5.496
            //      3   10.529
            // With N=7, Window 12h, Min. Span = 1h
            //      #     Time
            //      1    0.724
            //      2    2.771
            //      3    4.020
            //      4    5.790
            //      5    7.331
            //      6    9.214
            //      7   10.673
        }

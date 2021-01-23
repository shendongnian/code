    class Program
    {
        static void Main(string[] args)
        {
            const double tol=1e-10;
            double x = 1;
            if(args.Length>0)
            {
                double.TryParse(args[0], out x);
            }
            int n=1;
            const int n_max=100;
            double y=x;
            while(n<n_max && y>tol)
            {
                y=y*x*x/(2*n*(2*n+1));
                n++;
            }
            Debug.WriteLine(string.Format( "x={0:R}, y={1:R}, n={2}", x, y, n));
        }
    }

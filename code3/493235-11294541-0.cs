    class Program
    {
        /// <summary>
        /// Calculate integral with trapezoidal rule
        /// </summary>
        /// <param name="h">The step size in x-axis</param>
        /// <param name="y">The array of values to integrate</param>
        /// <returns>The area under the curve y[i,0]</returns>
        public static double Integrate(double h, double[,] y)
        {
            int N=y.GetLength(0);
            double sum=(y[0, 0]+y[N-1, 0])/2;
            for(int i=1; i<N-1; i++)
            {
                sum+=y[i, 0];
            }
            return h*sum;
        }
        static void Main(string[] args)
        {
            int N = 100;
            double[,] y=new double[N, 1];
            for(int i=0; i<y.GetLength(0); i++)
            {
                y[i, 0]=5+5*Math.Sin(2*Math.PI*i/(N-1));
            }
            double x_min=0.5;
            double x_max=3.5;
            double h = (x_max-x_min)/N;
            double area=Integrate(h, y);
            // expected answer is   area = 15.00
            // actual answer is     area = 14.85
        }
    }

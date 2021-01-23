    class Program
    {
        static Random rnd=new Random();
        static void Main(string[] args)
        {
            Historgram<double> hist=new Historgram<double>();
            for(int i=0; i<1000; i++)
            {
                double x=Math.Round(rnd.NextDouble(), 1);
                hist.Add(x);
            }
            //double[] values=hist.Values;
            Console.WriteLine("Histogram");
            Console.WriteLine("{0,12} {1,12}", "Value", "Quantity");            
            for(int i=0; i<=10; i++)
            {
                double x=(i/10d);
                Console.WriteLine("{0,12} {1,12}", x, hist[x]);
            }
            Console.ReadLine();
        }

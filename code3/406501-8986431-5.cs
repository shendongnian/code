    class Program
    {
        static void Main(string[] args)
        {
            StandardKernel kernel = new StandardKernel(new CalculatorModule());
            var cal = kernel.Get<ICalculator>();
            cal.Calculate();
        }
    }

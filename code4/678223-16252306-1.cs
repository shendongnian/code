      class Program
    {
        static void Main(string[] args)
        {
            var str = "10,23";
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("uz-Cyrl-UZ");
            Thread.CurrentThread.CurrentCulture = new CultureInfo("uz-Cyrl-UZ");
            Console.WriteLine(str.AsLocaleDouble());
            Console.ReadKey(); 
        }
    }
  

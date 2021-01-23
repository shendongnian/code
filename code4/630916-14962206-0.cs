    static void Main(string[] args)
    {
        for (int tester = 0; tester < 2000; tester++)
        {
            using (var service = new ConsoleApplication1.ServiceReference1.Service1Client())
            {
                Package result = service.GetPackageByIdTest(Guid.NewGuid(), tester);
                Console.WriteLine(result.ProductId);
            }
        }
        Console.ReadKey();
        return;
    }

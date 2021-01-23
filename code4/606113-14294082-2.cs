    class Program
    {
        static void Main(string[] args)
        {
            var vm = new MainPageViewModel();
            var task = vm.GetAllEvents();
            task.Wait();
            foreach (Event e in task.Result)
            {
                Console.WriteLine("{0} [{1}]", e.Title, e.DateTime);
                Console.WriteLine("Forecast: {0} (Previous: {1})", e.Forecast, e.Previous);
                Console.WriteLine();
            }
        }
    }

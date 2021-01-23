    class Program
    {
        static void Main(string[] args)
        {
            //Retrieve all Module types in the current Assembly.
            var moduletypes = Assembly.GetExecutingAssembly()
                                      .GetTypes()
                                      .Where(x => x.IsSubclassOf(typeof(ConsoleModule)));
            
            //Create an instance of each module
            var modules = moduletypes.Select(Activator.CreateInstance)
                                     .OfType<ConsoleModule>()
                                     .OrderBy(x => x.Id)
                                     .ToList();
            
            int SelectedOption = -1;
            
            while (SelectedOption != 0)
            {
                //Show Main Menu    
                Console.Clear();
                Console.WriteLine("Please Select An Option:\n");
                modules.ForEach(x => Console.WriteLine(string.Format("{0} - {1}", x.Id, x.DisplayName)));
                Console.WriteLine("0 - Exit\n");
                int.TryParse(Console.ReadLine(), out SelectedOption);
                //Find Module by Id based on user input
                var module = modules.FirstOrDefault(x => x.Id == SelectedOption);
                
                if (module != null)
                {
                    //Execute Module
                    Console.Clear();
                    module.Execute();
                    Console.WriteLine("Press Enter to Continue...");
                    Console.ReadLine();
                }
            }
        }

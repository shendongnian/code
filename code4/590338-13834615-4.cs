    //TODO: manage exceptions
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Total # of processors: {0}", Environment.ProcessorCount);
            Console.WriteLine("Current processor affinity: {0}", Process.GetCurrentProcess().ProcessorAffinity);
            Console.WriteLine("*********************************");
            Console.WriteLine("Insert your selected processors, separated by comma (first CPU index is 1):");
            var input = Console.ReadLine();
            Console.WriteLine("*********************************");
            var usedProcessors = input.Split(',');
            //TODO: validate input
            int newAffinity = 0;
            foreach (var item in usedProcessors)
            {
                newAffinity = newAffinity | int.Parse(item);
                Console.WriteLine("Processor #{0} was selected for affinity.", item);
            }
            Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)newAffinity;
            Console.WriteLine("*********************************");
            Console.WriteLine("Current processor affinity is {0}", Process.GetCurrentProcess().ProcessorAffinity);
        }
    }

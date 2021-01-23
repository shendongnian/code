    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("# of processors {0}", Environment.ProcessorCount);
            Console.WriteLine("Current processro affinity is {0}", Process.GetCurrentProcess().ProcessorAffinity);
            Console.WriteLine("Insert used processors, separated by comma:");
            var input = Console.ReadLine();
            var usedProcessors = input.Split(',');
            //TODO: validate input
            int newAffinity = 0;
            foreach (var item in usedProcessors)
            {
                newAffinity = newAffinity | int.Parse(item);
            }
            Process.GetCurrentProcess().ProcessorAffinity = (System.IntPtr)newAffinity;
            Console.WriteLine("Current processro affinity is {0}", Process.GetCurrentProcess().ProcessorAffinity);
        }
    }

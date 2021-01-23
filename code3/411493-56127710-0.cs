    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            var exeFilePath = Assembly.GetExecutingAssembly().Location;
            var psi = new ProcessStartInfo(exeFilePath, "CHILD");
            psi.UseShellExecute = false;
            psi.RedirectStandardInput = true;
            Console.WriteLine("Parent - Starting child process");
            var childProcess = Process.Start(psi);
            var bf = new BinaryFormatter();
            object[] data = Enumerable.Range(1, 100000)
                .Select(i => (object)$"String-{i}")
                .Append(13)
                .Append(DateTime.Now)
                .Append(new DataTable("Customers"))
                .ToArray();
            Console.WriteLine("Parent - Sending data");
            bf.Serialize(childProcess.StandardInput.BaseStream, data);
            Console.WriteLine("Parent - WaitForExit");
            childProcess.WaitForExit();
            Console.WriteLine("Parent - Closing");
        }
        else
        {
            Console.WriteLine("Child - Started");
            var bf = new BinaryFormatter();
            Console.WriteLine("Child - Reading data");
            var data = (object[])bf.Deserialize(Console.OpenStandardInput());
            Console.WriteLine($"Child - Data.Length: {data.Length}");
            Console.WriteLine("Child - Closing");
        }
    }

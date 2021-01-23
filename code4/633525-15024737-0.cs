    class Program
    {
        public static void Main()
        {
            EventLog myNewLog = new EventLog("Security", ".", "Microsoft Windows security");
            myNewLog.EntryWritten += new EntryWrittenEventHandler(MyOnEntryWritten);
            myNewLog.EnableRaisingEvents = true;
            Console.ReadLine();
        }
        public static async void MyOnEntryWritten(object source, EntryWrittenEventArgs e)
        {
            await Task.Factory.StartNew(() =>
            {
                if (e.Entry.InstanceId == 4656 || e.Entry.InstanceId == 4663)
                {
                    Console.WriteLine(e.Entry.Message);
                }
            });
        }
    }

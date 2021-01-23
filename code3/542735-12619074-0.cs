    namespace Build_Server_Lync_Notifier
        {
            class Program
            {
                static void Main(string[] args)
                {
                    if (args.Length != 2)
                    {
                        Console.WriteLine("Usage: bsln.exe <uri> <message>");
                        return;
                    }
                    LyncManager lm = new LyncManager(args[0], args[1]);
                    while (!lm.Done) {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
        }

    static Task<string> ReadFile(string filename, Action<string> updateStatus)
    {
        
        //do stuf synchronously
        return Task<string>.Factory.StartNew(() => {
            System.Threading.Thread.Sleep(1000);
            //do async stuff
            updateStatus("update message");
            //do other stuff
            return "The result";
        });
    }
    public static void Main(string[] args) 
    {
        var getStringTask = ReadFile("File.txt", (update) => {
            Console.WriteLine(update)
        });
        Console.Writeline("Reading file...");
        //do other stuff here
        //getStringTask.Result will wait if not complete
        Console.WriteLine("File contents: {0}", getStringTask.Result);
    }

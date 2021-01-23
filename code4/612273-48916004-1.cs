    public static void Main(string[] args)
    {
        string result = DownloadContentAsync().Result;
        Console.ReadKey();
    }
    // You use the async keyword to mark a method for asynchronous operations.
    // The "async" modifier simply starts synchronously the current thread. 
    // What it does is enable the method to be split into multiple pieces.
    // The boundaries of these pieces are marked with the await keyword.
    public static async Task<string> DownloadContentAsync()// By convention, the method name ends with "Async
    {
        using (HttpClient client = new HttpClient())
        {
            // When you use the await keyword, the compiler generates the code that checks if the asynchronous operation is finished.
            // If it is already finished, the method continues to run synchronously.
            // If not completed, the state machine will connect a continuation method that must be executed WHEN the Task is completed.
            // It will take 1 second to run because the Tasks are running synchronously, ie all at the same time.
            var a = Task.Delay(1000);
            var b = Task.Delay(1000);
            var c = Task.Delay(1000);
            await a;
            await b;
            await c;
        
            // It will take 3 seconds to complete, since each Task takes 3 seconds, since they are executed after the end of the previous one.
            await Task.Delay(1000);
            await Task.Delay(1000);
            await Task.Delay(1000);
            // Http request example. 
            // (In this example I can set the milliseconds after "sleep =")
            String result = await client.GetStringAsync("http://httpstat.us/200?sleep=1000");
            Console.WriteLine(result);
            // After completing the result response, the state machine will continue to synchronously execute the other processes.
           
            return result;
        }
    }
  

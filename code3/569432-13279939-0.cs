    	public static void Main()
		{
	        var task = Task.Factory.StartNew(() => {
 				Console.WriteLine("Starting blocking test...");
				Console.ReadLine();
	        int index = Task.WaitAny(new[] { task }, TimeSpan.FromSeconds(1));
	        Console.WriteLine(index); // Prints -1, timeout
	
	        var cts = new CancellationTokenSource();
	
	        // Just a simple way of getting a cancellable task
	        Task cancellable = task.ContinueWith(ignored => {}, cts.Token);
	
	        // It doesn't matter that we cancel before the wait
	        cts.Cancel();
	
	        index = Task.WaitAny(new[] { cancellable }, TimeSpan.FromSeconds(1));
	        Console.WriteLine(index); // 0 - task 0 has completed
	        Console.WriteLine(cancellable.Status); // Cancelled
		}

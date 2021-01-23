    public class Test
    {
    	public void Go()
    	{
    		ThreadPool.QueueUserWorkItem((z) => this.Imp());
    	}
    
    	private void Imp()
    	{
    		Console.WriteLine("Asynchronous operation in progress (1/2)...");
    		Thread.Sleep(2000);
    		Console.WriteLine("Asynchronous operation in progress (2/2)...");
    
    		if (this.Done != null)
    		{
    			this.Done(this, EventArgs.Empty);
    		}
    	}
    
    	public event EventHandler Done;
    }
    
    internal class Program
    {
    	private static void Main(string[] args)
    	{
    		Test test = new Test();
    
    		TaskCompletionSource<object> tcs = new TaskCompletionSource<object>(null);
    
    		Console.WriteLine("Starting asynchronous operation");
    
    		Task.Factory.StartNew(() =>
    		{
    			test.Done += (sender, e) => tcs.SetResult(null);
    			test.Go();
    		});
    
    		// Blocking until completion of the async operation
    		var tmp = tcs.Task.Result;
    
    		Console.WriteLine("Asynchronous operation completed");
    
    		Console.ReadKey();
    	}
    }

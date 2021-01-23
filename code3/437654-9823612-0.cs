    public class Test
    {
    	public void Go()
    	{
    		ThreadPool.QueueUserWorkItem((z) => this.Imp());
    	}
    
    	private void Imp()
    	{
    		Console.WriteLine("Waiting in another thread...");
    		Thread.Sleep(2000);
    		Console.WriteLine("Wait completed !");
    
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
    
    		Console.WriteLine("Starting in main thread");
    
    		Task.Factory.StartNew(() =>
    		{
    			test.Done += (sender, e) => tcs.SetResult(null);
    			test.Go();
    		});
    
    		// Blocking until completion of the task
    		var tmp = tcs.Task.Result;
    
    		Console.WriteLine("Operation of another thread completed !");
    
    		Console.ReadKey();
    	}
    }

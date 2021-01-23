     bool doneProcessing;
     TaskCompletionSource < bool > tcs = new TaskCompletionSource < bool > ();
    
    
     public void function1(string someParameter)
     {
         doneProcessing = false;
    
         Task < bool > b = InvokeScript("IDontCare");
	 Console.WriteLine ("What's up?...");
         b.ContinueWith(_ => Console.WriteLine("finished!")); //magic is here
	 Console.WriteLine ("Im not blocking...");
	   
     }
    
    
     public Task < bool > function2(string someParameter)
     {
	 new Thread(()=> {Thread.Sleep(2000); tcs.SetResult(true);}).Start();
         return tcs.Task;
     }
    
     public Task < bool > InvokeScript(string someParameter)
     {
         return function2(someParameter);
     }
    
   
    
     void Main()
     {
         function1("1");
         Console.ReadLine();    
     } 
    // output :What's up?...
    Im not blocking...
    finished

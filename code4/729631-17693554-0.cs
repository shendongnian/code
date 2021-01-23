     bool doneProcessing;
     TaskCompletionSource < bool > tcs = new TaskCompletionSource < bool > ();
    
    
     public void function1(string someParameter)
     {
         doneProcessing = false;
    
         Task < bool > b = InvokeScript("IDontCare");
         b.ContinueWith(_ => Console.WriteLine("aaaaaaa")); //magic is here
         //Wait till variable doneProcessing becomes true;
    
         //Continue from here after doneProcessing is true
    
     }
    
    
     public Task < bool > function2(string someParameter)
     {
         tcs.SetResult(true);
         return tcs.Task;
     }
    
     public Task < bool > InvokeScript(string someParameter)
     {
         Thread.Sleep(1000);
         return function2(someParameter);
     }
    
    
    
    
     void Main()
     {
         function1("1");
         Console.ReadLine();     // output : delay...."aaaaa"
     }

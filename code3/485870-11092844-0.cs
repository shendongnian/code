       string _name;
       ManualResetEvent _completed = new ManualResetEvent();
       public string Get()
       {
         //Some Statements
         _completed.Reset();
         //Asynchronous call to a method and its call back method is X
         //*Want to stop here until the Call back is finished
         _completed.WaitOne();
         return _name ;
       }
       private void X (IAsyncResult iAsyncResult)
       {
         //Call Endinvoke and get the result
         //assign the final result to global variable _name 
         _completed.Set();
       }

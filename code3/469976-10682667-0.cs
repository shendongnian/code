    public partial class main : Window 
    {         
        //...
        public void change() 
        { 
            if(Dispatcher.Thread.ManagedThreadId == Thread.ManagedThreadId)
            {
                // The method was called within the UI thread
                label1.Content = "hello"; 
            }
            else
            {
                // The method was called from different thread and we need to call Invoke
                var callback = new Action(change);
                Dispatcher.Invoke(callback);
            }
        } 
        //..
    } 

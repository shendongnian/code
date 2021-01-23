    //This has to be done on the UI-Thread, before calling the async method
    var dispatcher = Dispatcher.CurrentDispatcher;
    //Now, in your async callback, do something like this
    private void AsyncCallback(IAsyncResult result){
        dispatcher.Invoke(new Action(() =>
        {
            //Create your form Here           
        }
    }

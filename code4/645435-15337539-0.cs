    //process item
    if(progressBar.Dispatcher.CheckAccess()){
    progressBar.Value += 1; //maybe calculate the number of items you are processing
    }
    else {
    //send a delegate to the dispatcher
    MyDelegate myDel = new MyDelegate(delegate() {
       progressBar.Value += 1;
    });    
    progressBar.Dispatcher.Invoke(myDel);
    }

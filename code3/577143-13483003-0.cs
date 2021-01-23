    CancellationTokenSource tokenSource = new CancellationTokenSource();
     Task.Factory.StartNew( () => {
        // Do work
        onCompleteCallBack(someResult);
      }  tokenSource.Token);
    
    private void cancel_Click(object sender, RoutedEventArgs e)
    {
        tokenSource.Cancel();
       
    }

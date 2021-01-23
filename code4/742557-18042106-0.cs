    private void startWrite(object sender, RoutedEventArgs e)
    {
        startButton.IsEnabled = false;
        stopButton.IsEnabled = true;
        _continue = true;
        Thread myThread = new Thread(startWriteThread);
        startWriteThread.Start();
    }
    private void startWriteThread()
    {
        Hello();
    }

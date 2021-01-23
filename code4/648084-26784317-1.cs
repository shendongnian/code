    private async void BtnProcess_Click(object sender, RoutedEventArgs e)
    {       
        BtnProcess.IsEnabled = false; //prevent successive clicks
        var p = new Progress<int>();
        p.ProgressChanged += (senderOfProgressChanged, nextItem) => 
                        { BtnProcess.Content = "Processing page " + nextItem; };
        var result = await Task.Run(() =>
        {
            var processor = new SynchronousProcessor();
            processor.ItemProcessed += (senderOfItemProcessed , e1) => 
                                    ((IProgress<int>) p).Report(e1.NextItem);
            var done = processor.WorkItWorkItRealGood();
            return done ;
        });
        BtnProcess.IsEnabled = true;
        BtnProcess.Content = "Process";
    }

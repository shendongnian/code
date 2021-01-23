    void CodeToExcecute()
    {
            test.Background = Brushes.Orange;
    
            for (double x = 0; x < 10000000000; )
            {
                x++;
            }
    
            test.Background = Brushes.Red;
    
    }
    void worker_DoWork(object sender, DoWorkEventArgs e)
    {
       Dispatcher.BeginInvoke(new Action(() => CodeToExcecute() ));
    }

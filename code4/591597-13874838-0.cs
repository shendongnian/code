    Thread t1 = new Thread(new ThreadStart(
    delegate()
    {
        for (int i = 1; i < 11; i++)
        {
        this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
            new Action(delegate()
                {                        
                        mytxt1.Text = "Counter is: " + i.ToString();                           
                    
                }));
         Thread.Sleep(1000);
         }             
    }));
    t1.Start();

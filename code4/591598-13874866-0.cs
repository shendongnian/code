    Thread t1 = new Thread(new ThreadStart(
        delegate()
        {
            for (int i = 1; i < 11; i++)
            {        
                var counter = i; //for clouser it is important
                this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                    new Action(delegate()
                    {                    
                        mytxt1.Text = "Counter is: " + counter.ToString();                                         
                    }));
               Thread.Sleep(1000);
            }
        }

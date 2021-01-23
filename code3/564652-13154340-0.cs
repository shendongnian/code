    // gui thread
    var syncContext = System.Threading.SynchronizationContext.Current;
    
    public void FirstNumber()
    {
            int j = r.Next(0, 50);
            int k = r.Next(50, 100);
            for (int i = j; i <= k; i++)
            {
                // Post or Send mth
                syncContext.Post((o) => 
                {
                 number1.Text = i.ToString();
                });
    
                Thread.Sleep(200);
            }
    }

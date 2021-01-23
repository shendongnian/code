    private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Long UI process context
        using (new LongUIProcessContext("Wait while loading..."))
        {
            Thread.Sleep(2000);
    
            // Sub long ui process context
            using (new LongUIProcessContext("Wait while loading 2..."))
            {
                Thread.Sleep(2000);
            } 
    
            // Another sub long ui process context
            using (new LongUIProcessContext("Wait while loading 3..."))
            {
                Thread.Sleep(2000);
            }
        }
    }

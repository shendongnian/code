        private void SynchronizationContext SyncContext = SynchronizationContext.Current;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread thread = new Thread(Work1);
            thread.Start(SyncContext);
        }
    
        private void Work1(object state)
        {
            SynchronizationContext syncContext = state as SynchronizationContext;
            syncContext.Post(UpdateTextBox, syncContext);
        }
    
        private void UpdateTextBox(object state)
        {
            Thread.Sleep(1000);
            string text = File.ReadAllText(@"c:\temp\log.txt");
            myTextBox.Text = text;
        }

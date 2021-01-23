    void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
    {
        // Marshal back to the UI thread.
        _synchronizationContext.Send(s => {
            // Will now show in Dutch, as this call is taking place
            // on the UI thread.
            MessageBox.Show(Properties.Resources.CalculationSheet);
        }, null);    
    }

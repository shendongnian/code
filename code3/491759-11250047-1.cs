    public void Button_Click(object sender, EventArgs args)
    {
        Button.Enabled = false;
        ThreadPool.QueueUserWorkItem(new WaitCallback(BackgroundProcessing));
    }
    
    private void BackgroundProcessing(object state)
    {
        var result = Processing(1, 2, 3);
    
        // Call back to UI thread with results
        Invoke(new Action(() => { 
            this.MyTextBox.Content = result;
            Button.Enabled = true;
         }));
    }
    
    private int Processing(int a, int b, int c)
    { 
       this.A = this.moreProcessing(a);
       this.B = this.moreProcessing(b);
       this.C = this.moreProcessing(c);
    
       int newInt = /* ... */
       return newInt;
    }

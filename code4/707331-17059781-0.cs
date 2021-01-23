    private void botCore()
    {
        if (CheckBox2.Checked == true)
        {
           Task coreTask = Task.Factory.StartNew(() => printMessage("1", "www.google.nl"));
           await Task.Delay(2000);
           coreTask.Stop() // AS you asked that it will stop.
    
            if  (coreTask.IsCompleted) // Checks if the 2000 milliseconds are up then executes another statement.
            {
               Task coreTask2 = Task.Factory.StartNew(() => printMessage("2", "www.google.nl?p=2"));
               await Task.Delay(3000);
               coreTask2.Stop() // AS you asked that it will stop.
            }
            Core.Stop();
        }
    }
    
    public void printMessage(string text, string url){
        MessageBox.Show("Proxy -> " + text);
        Webbrowser1.Navigate(url)
    }

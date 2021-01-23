    void Button_Click(object sender, EventArgs args)
    {
        BackgroundWorker worker = new BackgroundWorker();
        worker.DoWork += (s, e) =>
                         {
                             e.Result = Processing(1, 2, 3);
                         };
        worker.RunWorkerCompleted += (s1, e1) =>
                                     {
                                         MyTextBox.Content = e1.Result;
                                         MyButton.IsEnabled = true;
                                     };
        
        // Disable the button to stop multiple clicks
        MyButton.IsEnabled = false;
        worker.RunWorkerAsync();
    }

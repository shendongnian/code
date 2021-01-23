    void client_DoWorkCompleted(object sender, DoWorkCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            listBox1.DisplayMemberPath = "PropertyA";
            listBox1.ItemsSource = e.Result;
        }
    }

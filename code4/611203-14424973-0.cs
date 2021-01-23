    void client_DoWorkCompleted(object sender, DoWorkCompletedEventArgs e)
    {
        if (e.Error == null)
        {
            listBox1.DisplayMember = "PropertyA";
            listBox1.ValueMember = "PropertyB";
            listBox1.ItemsSource = e.Result;
        }
    }

    private void button1_Click(object sender, RoutedEventArgs e)
    {
        label1.Content = "In progress..";
        Task.Factory.StartNew<List<string>>(
        () =>
        {
            List<string> intList = new List<string>();
            for (long i = 0; i <= 50000000; i++)
            {
                intList.Add("Test");
            }
            return intList;
        })
        .ContinueWith<List<string>>(
            (t) => label1.Content = t.Result.ToString(),
            TaskScheduler.FromCurrentSynchronizationContext());
    }

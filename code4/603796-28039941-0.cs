    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        FunctionA();
    }
    public void FunctionA()
    {
        Task.Delay(5000).Wait();
        MessageBox.Show("Waiting Complete");
    }

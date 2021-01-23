    private void Button_Click_2(object sender, RoutedEventArgs e)
    {
        FunctionA();
    }
    public async void FunctionA()
    {
        await Task.Delay(5000);
        MessageBox.Show("Waiting Complete");
    }

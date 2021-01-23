    <StackPanel>
        <TextBox x:Name="txt1" Width="150" Margin="10" KeyUp="txt1_KeyUp"/>
    </StackPanel>   
    
    private void txt1_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            txt1.IsEnabled = false;
            Thread t = new Thread(() =>
            {
                System.Threading.Thread.Sleep(2500);
                Action action = () => txt1.IsEnabled = true;
                Dispatcher.Invoke(action);
            });
            t.Start();
        }
    }

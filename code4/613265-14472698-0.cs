    protected override void OnStartup(StartupEventArgs e)
    {
        EventManager.RegisterClassHandler(typeof(TextBox),
            TextBox.KeyUpEvent,
            new System.Windows.Input.KeyEventHandler(AddKeyword));
        base.OnStartup(e);
    }
    private void AddKeyword(object sender, System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Enter)
        {
            // your event handler here
            e.Handled = true;
            MessageBox.Show("Enter pressed");
        }
    }

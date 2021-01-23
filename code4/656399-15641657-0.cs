    private void Process()
    {
        this.Dispatcher.BeginInvoke(() => this.TextBox1.Text = "Hello");
        Thread.Sleep(1000);
        this.Dispatcher.BeginInvoke(() => this.Picture1.Visibility = Visibility.Visible);
        Thread.Sleep(1000);
        this.Dispatcher.BeginInvoke(() => this.TextBox2.Text = "World");
    }

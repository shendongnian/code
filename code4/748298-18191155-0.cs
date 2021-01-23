    private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        // Doing something
    }
=>
    private DoingSomething()
    {
        // Doing something
    }
    private void PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        DoingSomething();
    }

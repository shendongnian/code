    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        base.OnNavigatedTo(e);
        if (e.NavigationMode != NavigationMode.Back)
        {
            Dispatcher.InvokeAsync(() => ShowKeyboard());
        }
    }
    private void ShowKeyboard()
    {
        textBox.Focus();
    }

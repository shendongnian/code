    private void OnLostFocus(...)
    {
        if (textIsValid)
        {
            this.Dispatcher.BeginInvoke((Action)() => button.Focus());
        }
    }

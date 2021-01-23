    private void AppendText(string text)
    {
        this.Dispatcher.Invoke((Action)(() =>
        {
            _window.Dev_output.Text += string.Format("{0}{1}", text, Environment.NewLine);
        }));
    }

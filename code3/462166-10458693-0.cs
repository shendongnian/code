    private void UpdateText(string message)
    {
        if (this.InvokeRequired)
        {
            UpdateDelegate update = new UpdateDelegate(UpdateText);
            this.Invoke(update, new object[] { message });
        }
        else
        {
            var V = message + System.Environment.NewLine + textHistory.Text;
            textHistory.Text = V;
            textHistory.Refresh();
        }
    }

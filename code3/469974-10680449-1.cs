    delegate void UpdateStatusDelegate (string value);
    private void UpdateStatus(string value)
    {
        if (InvokeRequired)
        {
            // We're not in the UI thread, so we need to call BeginInvoke
            BeginInvoke(new UpdateStatusDelegate(UpdateStatus), new object[]{value});
            return;
        }
        // Must be on the UI thread if we've got this far
        statusIndicator.Text = value;
    }

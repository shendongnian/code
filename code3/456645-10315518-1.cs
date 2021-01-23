    private void UpdateLabel(string text)
    {
        if (this.IsHandleCreated)
        {
            this.Invoke((MethodInvoker)delegate
            {
                label.Text = text;
            });
        }
        else
        {
            label.Text = text;
        }
    }

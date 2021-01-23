    public void PrintMessage(Action<string> displayAction)
    {
        string text = string.Empty;
        if (txtOutput.InvokeRequired)
        {
            txtOutput.BeginInvoke(new MethodInvoker(delegate
            {
                displayAction.Invoke(txtOutput.Text);
            }));
        }
        else
        {
            displayAction.Invoke(txtOutput.Text);
        }
    }

    using (TcpClient client = (TcpClient)result.AsyncState)
    {
        try
        {
            client.EndConnect(result);
            this.Invoke((MethodInvoker)delegate
            {
                txtDisplay.Text += "open" + Environment.NewLine;
            });
        }
        catch
        {
            this.Invoke((MethodInvoker)delegate
            {
                txtDisplay.Text += "closed" + Environment.NewLine;
            });
        }

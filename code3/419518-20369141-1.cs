    if (button3.Text != "&Start Upload")
    {
        cancellationTokenSource.Cancel();
    }
    else
    {
        try
        {
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;
            Task.Factory.StartNew(StartUpload, cancellationToken);
        }
        catch (AggregateException ex)
        {
            var builder = new StringBuilder();
            foreach (var v in ex.InnerExceptions)
                builder.Append("\r\n" + v.InnerException);
            MessageBox.Show("There was an exception:\r\n" + builder.ToString());
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

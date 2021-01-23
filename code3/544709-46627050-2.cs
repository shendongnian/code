    async Task UserSubmitClickAsync(CancellationToken cancellationToken)
    {
       try
       {
          await SendResultAsync(cancellationToken);
       }
       catch (OperationCanceledException) // includes TaskCanceledException
       {
          MessageBox.Show(“Your submission was canceled.”);
       }
    }
    

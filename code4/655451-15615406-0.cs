    CancellationTokenSource cts;
    private async void ScreenTap(object sender, System.Windows.Input.GestureEventArgs e)
    {
      if (cts == null)
      {
        cts = new CancellationTokenSource();
        try
        {
          await DoSomethingAsync(cts.Token);
        }
        catch (OperationCanceledException)
        {
        }
      }
      else
      {
        cts.Cancel();
        cts = null;
      }
    }
    private async Task DoSomethingAsync(CancellationToken token) 
    {
      playing = true;
      for (int i = 0; ; count++)
      {
        token.ThrowIfCancellationRequested();
        await doingsomethingAsync(text, token);
      }
      playing = false;
    }

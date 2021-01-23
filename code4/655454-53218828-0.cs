    private async void DoSomething(CancellationToken token) 
    {
        playing = true;
        for (int i = 0; keepdoing ; count++)
        {
            if(token.IsCancellationRequested)
            {
             // Do whatever needs to be done when user cancels or set return value
             return;
            }
            await doingsomething(text);
        }
        playing = false;
    }

    CancellationTokenSource tokenSource; // member variable in your Form
    // Initialize and wait for input on Form.Load.
    async void Form_Load(object sender, EventArgs e)
    {
      tokenSource = new CancellationTokenSource();
      await WaitForInput(tokenSource.Token);
      // ENTER was pressed!
    }
    // Our TextBox has input, cancel the wait if ENTER was pressed.
    void TextBox_KeyDown(object sender, KeyEventArgs e)
    {
      // Wait for ENTER to be pressed.
      if(e.KeyCode != Keys.Enter) return;
      if(tokenSource != null)
        tokenSource.Cancel();
    }
     
    // This method will wait for input asynchronously.
    static async Task WaitForInput(CancellationToken token)
    {
      await Task.Delay(-1, token); // wait indefinitely
    }
    
    

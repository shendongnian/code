    public async Task FlashButtons()
    {
        foreach (Button button in buttons) // No need for a for loop here
        {
            button.BackColor = Color.Red;
            await Task.Delay(500);
            button.BackColor = Color.Green;
        }
    }

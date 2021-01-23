    private void Initalize()
    {
         TwoUp.SetUpCoins();
        
    }
    private void  Button1_click(object sender, EventArgs e)
    {
    
         TwoUp.ThrowCoins();
         TwoUp.OutputWinner();
         TwoUp.HoldPoints();
         TwoUp.ResetGlobals(); // Optional - not sure what this does...
    }

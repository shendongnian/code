    void startTimer()
    { 
         if (snakeScoreLabel.Text == "100")
         {
          System.Timers.Timer timer = new System.Timers.Timer(1000) { Enabled = true }; 
          timer.Elapsed += (sender, args) => 
            { 
               lblWin1.Visible=true;
               timer.Dispose(); 
            }; 
         }
        
    } 

    // usage
    foreach(var button in GetAnswerButtons())
    {
        button.Click += OnClickToBold;
        button.Click += OnClickSetPropertyBasedOnCorrectness;
    }
    
    nextButton.Click += NextClick;
    
    
    // implementations    
    private void OnClickToBold(object sender, EventArgs e)
    {
       var button = sender as Button;
    
       if (button == null) return;
    
       button.Font = new Font(button.Font.Name, button.Font.Size, FontStyle.Bold);
    }
    private void OnClickSetPropertyBasedOnCorrectness(object sender, EventArgs e)
    {
       var button = sender as Button;
    
       if (button == null) return;
       button.WhateverProperty = IsCorrectAnswer(button) 
           ? valueWhenCorrect
           : valueWhenWrong;
    }
    
    private void NextClick(object sender, EventArgs e)
    {
        foreach(var button in GetAnswerButtons())
        {
            button.Font = new Font(button.Font.Name, button.Font.Size, FontStyle.Regular);
        }
    }
    
    private IEnumerable<Button> GetAnswerButtons() { ... }

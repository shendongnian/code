    OnRichTextChanged() 
    {
       StopExisingSyntaxHighlighterTimer();
       StartSyntaxHighlighterTimer(TimeSpan.FromSeconds(5));
    }
    OnSyntaxHighlighterTimerFired() 
    {
       StopExisingSyntaxHighlighterTimer();
       DoSyntaxHighlighting();
    }
    

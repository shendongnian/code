    private void OnTabLoaded(object sender, RoutedEventArgs e)
    {
       textEditor.SyntaxHighlighting = HighlightingLoader.Load(..., HighlightingManager.Instance);
       textEditor.SyntaxHighlighting.MainRuleSet=...
    }

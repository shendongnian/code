    public interface ITextView
    {
        string InputtedText { get; }
        string SessionTextEntry { get; set; }
        void RedirectToTestPage();
    
        event EventHandler ButtonClickedEvent;
    }

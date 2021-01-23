    public interface IHasBottomPanel
    {
        event EventHandler WindowClosing;
        DialogResult DialogResult { get; set; }
        BottomPanelViewModel BottomPanelViewModel { get; set; }
        
        void ExecuteOkCommand(object sender, ExecutedRoutedEventArgs e);
        ...
        void CanExecuteOkCommand(object sender, CanExecuteRoutedEventArgs e);
        ...
    }
 

    // The view model
    public class MainWindowViewModel
    {
        // The button click command
        public RelayCommand ButtonClickCommand { get; set; }
        // The event to fire
        public event EventHandler<ShowMessageEventArgs> ShowMessage;
        
        public MainWindowViewModel()
        {            
            ButtonClickCommand = new RelayCommand(ButtonClicked);            
        }
        void ButtonClicked(object param)
        {
            // This button is wired up in the view as normal and fires the event
            OnShowMessage("You clicked the button");
        }
 
        // Fire the event - it's up to the view to decide how to implement this event and show a message
        void OnShowMessage(string message)
        {
            if (ShowMessage != null) ShowMessage(this, new ShowMessageEventArgs(message));
        }
    }
    public class ShowMessageEventArgs : EventArgs
    {
        public string Message { get; private set; }
        public ShowMessageEventArgs(string message)
        {
            Message = message;
        }
    }

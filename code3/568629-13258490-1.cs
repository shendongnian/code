    public class CustomMessageControlEventArgs : EventArgs
    {
        public CustomMessageViewModel CustomMessageViewModel { get; set; }
    }
    
    public event EventHandler<CustomMessageControlEventArgs> 
        ShowCustomMessageControl;
    
    private void marker_TouchDown(MessageObject msgData)
    {
        // Create the view model.
        var message = ;
    
        // Get the events.
        var events = ShowCustomMessageControl;
    
        // Fire.
        if (events != null) events(this, 
            new CustomMessageControlEventArgs {
                MessageObject = new CustomMessageViewModel(msgData)
            });
    }

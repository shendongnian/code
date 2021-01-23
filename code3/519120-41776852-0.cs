    public class CloseDialogMessage : NotificationMessage
    {
        public CloseDialogMessage(object sender) : base(sender, "") { }
    }
    private void OnClose()
    {
        Messenger.Default.Send(new CloseDialogMessage(this));
    }

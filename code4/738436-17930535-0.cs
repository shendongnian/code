    public partial class ClientChangedEventArgs : EventArgs
    {
        public ClientChangedEventArgs(string mewText)
        {
            this.NewText = newText;
        }
        public string NewText;
    }

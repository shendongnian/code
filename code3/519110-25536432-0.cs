    public class CloseableViewModel
    {
        public CloseableViewModel()
        {
            CloseCommand = new RelayCommand(this.OnClosingRequest);
        }
        public event EventHandler ClosingRequest;
        protected void OnClosingRequest()
        {
            if (this.ClosingRequest != null)
            {
                this.ClosingRequest(this, EventArgs.Empty);
            }
        }
        public RelayCommand CloseCommand
        {
        get;
        private set;
        }
    }

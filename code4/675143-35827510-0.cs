    public class MainWindowViewModel : BindableBase, ICloseable
    {
        public DelegateCommand SomeCommand { get; private set; }
        #region ICloseable Implementation
        public event EventHandler CloseRequested;        
        public void RaiseCloseNotification()
        {
            var handler = CloseRequested;
            if (handler != null)
            {
                handler.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
        public MainWindowViewModel()
        {
            SomeCommand = new DelegateCommand(() =>
            {
                //when you decide to close window
                RaiseCloseNotification();
            });
        }
    }

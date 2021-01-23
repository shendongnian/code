     [Export(typeof (IShell))]
        public class ShellViewModel : PropertyChangedBase, IShell
        {
            private bool _isOpen;
            public bool IsOpen
            {
                get { return _isOpen; }
                set
                {
                    _isOpen = value;
                    NotifyOfPropertyChange(() => IsOpen);
                    NotifyOfPropertyChange(() => CanSettings);
                }
            }
    
            private bool _isSettings;
            public bool IsSettings
            {
                get { return _isSettings; }
                set
                {
                    _isSettings = value;
                    NotifyOfPropertyChange(() => IsSettings);
                    NotifyOfPropertyChange(() => CanResults);
                }
            }
    
            public bool IsResults { get; set; }
    
            public void Open()
            {
                IsOpen = true;
            }
    
            public bool CanSettings
            {
                get { return IsOpen; }
            }
    
            public void Settings()
            {
                IsSettings = true;
            }
    
            public bool CanResults
            {
                get { return IsSettings; }
            }
    
            public void Results()
            {
            }
        }

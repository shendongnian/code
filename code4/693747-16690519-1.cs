    class MainWindowViewModel
    {
        private ICommand m_ButtonCommand;
        public ICommand ButtonCommand
        {
            get
            {
                return m_ButtonCommand;
            }
            set
            {
                m_ButtonCommand = value;
            }
        }
    
        public MainWindowViewModel()
        {
            ButtonCommand=new RelayCommand(new Action<object>(ShowMessage));
        }
    
        public void ShowMessage(object obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }

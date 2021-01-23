    public sealed class ViewModel : INotifyPropertyChanged
    {
        #region Members: Fields
        private Boolean m_ButtonAttachEnabled;
        private Boolean m_ButtonDetachEnabled;
        private Boolean m_ButtonRefreshEnabled;
        private Boolean m_ComboBoxEnabled;
        private Boolean m_ProgressBarEnabled;
        private ViewModelBase m_SelectedItem;
        private Dictionary<String, PropertyChangedEventArgs> m_PropertyChangedEventArgs = new Dictionary<String, PropertyChangedEventArgs>();
        private Double m_ProgressBarMaximum;
        private Double m_ProgressBarValue;
        private IntPtr m_ProcessHandle;
        private IntPtr m_ProcessHook;
        private ObservableCollection<ViewModelBase> m_Items;
        private Visibility m_WatermarkVisibility;
        #endregion
        #region Members: INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public Boolean ButtonAttachEnabled
        {
            get { return m_ButtonAttachEnabled; }
            private set
            {
                if (m_ButtonAttachEnabled != value)
                {
                    m_ButtonAttachEnabled = value;
                    NotifyPropertyChanged("ButtonAttachEnabled");
                }
            }
        }
        public Boolean ButtonDetachEnabled
        {
            get { return m_ButtonDetachEnabled; }
            private set
            {
                if (m_ButtonDetachEnabled != value)
                {
                    m_ButtonDetachEnabled = value;
                    NotifyPropertyChanged("ButtonDetachEnabled");
                }
            }
        }
        public Boolean ButtonRefreshEnabled
        {
            get { return m_ButtonRefreshEnabled; }
            private set
            {
                if (m_ButtonRefreshEnabled != value)
                {
                    m_ButtonRefreshEnabled = value;
                    NotifyPropertyChanged("ButtonRefreshEnabled");
                }
            }
        }
        public Boolean ComboBoxEnabled
        {
            get { return m_ComboBoxEnabled; }
            private set
            {
                if (m_ComboBoxEnabled != value)
                {
                    m_ComboBoxEnabled = value;
                    NotifyPropertyChanged("ComboBoxEnabled");
                }
            }
        }
        public Boolean ProgressBarEnabled
        {
            get { return m_ProgressBarEnabled; }
            private set
            {
                if (m_ProgressBarEnabled != value)
                {
                    m_ProgressBarEnabled = value;
                    NotifyPropertyChanged("ProgressBarEnabled");
                }
            }
        }
        public ViewModelBase SelectedItem
        {
            get { return m_SelectedItem; }
            set
            {
                if (m_SelectedItem != value)
                {
                    m_SelectedItem = value;
                    NotifyPropertyChanged("SelectedItem");
                }
            }
        }
        public Double ProgressBarMaximum
        {
            get { return m_ProgressBarMaximum; }
            private set
            {
                if (m_ProgressBarMaximum != value)
                {
                    m_ProgressBarMaximum = value;
                    NotifyPropertyChanged("ProgressBarMaximum");
                }
            }
        }
        public Double ProgressBarValue
        {
            get { return m_ProgressBarValue; }
            private set
            {
                if (m_ProgressBarValue != value)
                {
                    m_ProgressBarValue = value;
                    NotifyPropertyChanged("ProgressBarValue");
                }
            }
        }
        public ObservableCollection<ViewModelBase> Items
        {
            get { return m_Items; }
            private set
            {
                if (m_Items != value)
                {
                    m_Items = value;
                    NotifyPropertyChanged("Items");
                }
            }
        }
        public Visibility WatermarkVisibility
        {
            get { return m_WatermarkVisibility; }
            private set
            {
                if (m_WatermarkVisibility != value)
                {
                    m_WatermarkVisibility = value;
                    NotifyPropertyChanged("WatermarkVisibility");
                }
            }
        }
        #endregion
        #region Constructors
        public ViewModel()
        {
            m_PropertyChangedEventArgs = new Dictionary<String, PropertyChangedEventArgs>();
            Populate();
        }
        #endregion
        #region Methods: Functions
        private PropertyChangedEventArgs GetPropertyChangedEventArgs(String propertyName)
        {
            PropertyChangedEventArgs propertyChangedEventArgs;
            if (!m_PropertyChangedEventArgs.TryGetValue(propertyName, out propertyChangedEventArgs))
                m_PropertyChangedEventArgs[propertyName] = propertyChangedEventArgs = new PropertyChangedEventArgs(propertyName);
            return propertyChangedEventArgs;
        }
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, GetPropertyChangedEventArgs(propertyName));
        }
        private void ResetProgressBar(Int32 maximumValue = 100)
        {
            ProgressBarMaximum = maximumValue;
            ProgressBarValue = 0;
        }
        private void SetInterfaceStatus(Status status)
        {
            switch (status)
            {
                case Status.Attached:
                    {
                        ButtonAttachEnabled = false;
                        ButtonDetachEnabled = true;
                        ButtonRefreshEnabled = false;
                        ComboBoxEnabled = false;
                        ProgressBarEnabled = false;
                        WatermarkVisibility = Visibility.Hidden;
                        break;
                    }
                case Status.Busy:
                    {
                        ButtonAttachEnabled = false;
                        ButtonDetachEnabled = false;
                        ButtonRefreshEnabled = false;
                        ComboBoxEnabled = false;
                        ProgressBarEnabled = true;
                        WatermarkVisibility = Visibility.Hidden;
                        break;
                    }
                case Status.Detached:
                    {
                        ButtonAttachEnabled = true;
                        ButtonDetachEnabled = false;
                        ButtonRefreshEnabled = true;
                        ComboBoxEnabled = true;
                        ProgressBarEnabled = true;
                        WatermarkVisibility = Visibility.Hidden;
                        goto default;
                    }
                case Status.DetachedEmpty:
                    {
                        ButtonAttachEnabled = false;
                        ButtonDetachEnabled = false;
                        ButtonRefreshEnabled = true;
                        ComboBoxEnabled = false;
                        ProgressBarEnabled = false;
                        WatermarkVisibility = Visibility.Visible;
                        goto default;
                    }
                default:
                    ResetProgressBar();
                    break;
            }
        }
        public void Attach()
        {
        }
        public void Detach()
        {
        }
        public void Populate()
        {
            ViewModelBase selectedItem = m_SelectedItem;
            SelectedItem = null;
            Items = new ObservableCollection<ViewModelBase>();
            List<ViewModelBase> ViewModelBases = new List<ViewModelBase>();
            if (selectedItem == null)
            {
                ViewModelBases.Add(new Test { TestValue = "123456789", TestEnum = TestEnum.A, TestBool = false, TestBool2 = true });
                ViewModelBases.Add(new Test { TestValue = "987365321", TestEnum = TestEnum.B, TestBool = true, TestBool2 = true });
                ViewModelBases.Add(new Test { TestValue = "784512457", TestEnum = TestEnum.B, TestBool = true, TestBool2 = true });
            }
            //foreach (Process process in Process.GetProcesses())
            //{
            //    if ((process.ProcessName == "chrome") && !process.HasExited && (process.MainModule.ModuleName == "chrome.exe"))
            //        ViewModelBases.Add(new ViewModelBase(ViewModelBaseType.Chrome, process));
            //}
            if (ViewModelBases.Count == 0)
                SetInterfaceStatus(Status.DetachedEmpty);
            else
            {
                Items = new ObservableCollection<ViewModelBase>(ViewModelBases);
                if (selectedItem != null)
                    SelectedItem = m_Items.SingleOrDefault(x => x.Equals(selectedItem));
                if (m_SelectedItem == null)
                    SelectedItem = m_Items[0];
                SetInterfaceStatus(Status.Detached);
            }
        }
        #endregion
        #region Enumerators
        private enum Status
        {
            Attached,
            Busy,
            Detached,
            DetachedEmpty
        }
        #endregion
    }

      ObservableCollection<String> m_NotificationList;
      // Propertized for binding purposes
      public ObservableCollection<String> NotificationList
      {
         get
         {
            return m_NotificationList;
         }
      }
      public MainWindow()
      {
         InitializeComponent();
         this.DataContext = this;
         m_NotificationList = new ObservableCollection<string>() { "hey", "ho", "lets", "go" };
         m_NotificationList.CollectionChanged += CollectionChangeCallback;
      }

    public MainWindow()
        {
            InitializeComponent();
            dgContacts.ItemsSource = Contacts;
        }
        private void btnClick_Click(object sender, RoutedEventArgs e)
        {
            Contacts.Add(new contact()
            {
                Name = "Person",
                Email = "Person Address",
                PhoneNumber = "Person Ph"
            });
        }
        protected ObservableCollection<contact> contacts = new ObservableCollection<contact>();
        public ObservableCollection<contact> Contacts
        {
            get { return contacts; }
            set { contacts = value; }
        }

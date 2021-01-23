        private BookingsViewModel _BookingsViewModel;
        public BookingsViewModel BookViewModel    // Property
        {
            get
            {
                return _BookingsViewModel;
            }
            set
            {
                _BookingsViewModel = value;
                OnPropertyChanged("BookViewModel");
            }
        }
    
        public GuestsViewModel(BookingsViewModel bvm)    // Constructor with one parameter
        {
            BookViewModel = bvm;
        }
        public ICommand _btnAddGuest;
        public ICommand btnAddGuest 
        {
            get
            {
                if (_btnAddGuest == null)
                {
                    _btnAddGuest = new DelegateCommand(delegate()
                    {
                        try
                        {
                            Service1Client wcf = new Service1Client();                           
                            wcf.AddGuest(Guest);
                            BookingsViewModel.OnPropertyChanged("Guests");    // You said to add this
                            wcf.Close();
                        }
                        catch
                        {
                            Trace.WriteLine("working...", "MyApp");
                        }
                    });
                }
                return _btnAddGuest;
            }
        }

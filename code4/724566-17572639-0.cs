    using GalaSoft.MvvmLight.Messaging;
    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = new MainViewModel();
        Messenger.Default.Register<NotificationMessage>(this, (nm) =>
        {
            //Check which message you've sent
            if (nm.Notification == "CloseWindowsBoundToMe")
            {
                //If the DataContext is the same ViewModel where you've called the Messenger
                if (nm.Sender == this.DataContext)
                    //Do something here, for example call a function. I'm closing the view:
                    this.Close();
            }
        });
    }

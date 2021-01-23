    public SearchDocumentView()
    {
        InitializeComponent();
        Messenger.Default.Register<NotificationMessage<Entity>>(this, NotificationMessageReceived);
    }

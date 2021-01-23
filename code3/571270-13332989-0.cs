    public Recipient Recipient
    {
        get { return _Recipient; }
        set
        {
            _Recipient = value;
            NotifyPropertyChanged("Recipient");
            NotifyPropertyChanged("MailingList");
        }
    } private Recipient _Recipient
    
    public EntityCollection<MailingList> MailingList
    {
        get { return _MailingList; }
        set
        {
            _MailingList= value;
            NotifyPropertyChanged("MailingList");
        }
    } private EntityCollection<MailingList> _MailingList

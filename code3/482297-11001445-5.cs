       public Form1()
        {
            mgr = new Manager(this);
            InitializeComponent();
    
            mgr.UpdateList();
        }
    
        public void SetBinding(BindingSource _messages)
        {
            lbMessages.DataSource = _messages;
    
            // NOTE that message is added later & will instantly appear on ListBox
            mgr.Messages.Add("I am added later");
            mgr.Messages.Add("blah, blah, blah");
        }

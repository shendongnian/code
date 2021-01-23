    public class AccountListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Accounts> accountList= 
                                               newObservableCollection<Accounts>();
        private string accountName;
        ICommand AddAccountCommand {get;set;}
        public event PropertyChangedEventHandler PropertyChanged;
        public AccountListViewModel()
        {
            ReadAllAccountsFromXml();
            AddAccountCommand=new  RelayCommand(AddAccountToListAndSave);
        }
        private void ReadAllAccountsFromXml()
        {           
            XmlTextReader reader = new XmlTextReader("Accounts.xml");
            
            //  Loop over the XML file
            while (reader.Read())
            {
                //  Here we check the type of the node, in this case we are looking for element
                if (reader.NodeType == XmlNodeType.Element)
                {
                    //  If the element is "accounts"
                    if (reader.Name == "Accounts")
                    {
                        var account = new Accounts()
                        account.AccountName=reader.Value;
                        AccountList.Add(account)
                    }
                }
            }
            reader.Close();
        }
        private void AddAccountToListAndSave(object obj)
        {
            var account = new Accounts();
            account.AccountName=AccountnName;
            AccountList.Add(account);
            SaveListToXml();
        }
        private void SaveListToXml()
        {
            //Write Xml Saving Code Here With Object as AccountList
        }
        public ObservableCollection<Accounts> AccountList
        {
            get { return accountList; }
            set
            {
                accountList = value;
                OnPropertyChanged("AccountList");
            }
        }
        public string AccountName
        {
            get { return accountnName; }
            set
            {
                accountnName = value;
                OnPropertyChanged("AccountName");
            }
        }
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }

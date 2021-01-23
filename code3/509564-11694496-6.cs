	public class Person : INotifyPropertyChanged 
    {
        public string OriginalFirstName = "Jim";
        public string OriginalLastName = "Smith";
        private string _firstName;
        #region FirstName
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (value != null)
                {
                    _firstName = value;
                    NotifyTheOtherGuy("CheckFirstName");
                }
            }
        }
        #endregion FirstName
        private string _lastName;
        #region LastName
        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (value != null)
                {
                    _lastName = value;
                    NotifyTheOtherGuy("CheckLastName");
                }
            }
        }
        #endregion LastName
        
        public string CheckFirstName
        {
        	get
        	{
        		return (FirstName==OriginalFirstName) ? "Original": "Modified";
        	}
        }
        public string CheckLastName
        {
        	get
        	{
        		return (LastName==OriginalLastName) ? "Original": "Modified";
        	}
        }
        
        public Person()
        {
        }
        public event PropertyChangedEventHandler PropertyChanged;
        void NotifyTheOtherGuy(string msg)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(msg));
            }
        }
    }

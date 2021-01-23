    public class yourCodeThatGetsYourFriends : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void GetFriends()
        {
            //get friends and put into friend objects defined below
            //create an ObservableCollection of them and assign it to the Friends (make sure its 'Friends' not 'friends") property
        }
        public ObservableCollection<friend> friends;
        public ObservableCollection<friend> Friends;
        {
            get
            {
                return friends;
            }
            set
            {
                friends = value;
                NotifyPropertyChanged("Friends");
            }
        }        
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class friend : INotifyPropertyChanged
    {        
        public event PropertyChangedEventHandler PropertyChanged;
        string url;
        public string avatarURL
        {
            get
            {
                return url;
            }
            set
            {
                url = value;
                NotifyPropertyChanaged("avatarURL");
            }
        }
        string tag;
        public string GamerTag
        {
            get
            {
                return tag;
            }
            set
            {
                tag= value;
                NotifyPropertyChanaged("GamerTag");
            }
        }
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

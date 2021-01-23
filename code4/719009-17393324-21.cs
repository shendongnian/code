    public class ChatViewModel:PropertyChangedBase
    {
        public ObservableCollection<ChatEntry> ChatEntries { get; set; }
        private string _userInput;
        public string UserInput
        {
            get { return _userInput; }
            set
            {
                _userInput = value;
                OnPropertyChanged("UserInput");
            }
        }
        public string NickName { get; set; }
        
        public ChatViewModel()
        {
            ChatEntries = new ObservableCollection<ChatEntry>();
            NickName = "John Doe";
        }
        public ChatEntry AddEntry()
        {
            var entry = new ChatEntry {DateTime = DateTime.Now, Sender = NickName};
            entry.Content = UserInput;
            ChatEntries.Add(entry);
            UserInput = null;
            return entry;
        }
    }

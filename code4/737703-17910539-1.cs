        public ObservableCollection<DictionaryEntry> MyItems { get; set; } 
        public ViewModel()
        {
            MyItems = new ObservableCollection<DictionaryEntry>();
            MyItems.Add(new DictionaryEntry{K="string1", V="value1"});
            MyItems.Add(new DictionaryEntry { K = "color", V = "red" });
        }

    public class Dict : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string SubName { get; set; }
        public bool Selected { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Dict> Dictionaries { get; set; }
        public ViewModel()
        {
            Dictionaries = new ObservableCollection<Dict>()
            {
                new Dict()
                    {
                        Name = "English",
                        SubName = "en",
                        Selected = false,
                    },
                    new Dict()
                    {
                        Name = "English-British",
                        SubName = "en-uk",
                        Selected = true
                    },
                    new Dict()
                    {
                        Name = "French",
                        SubName = "fr",
                        Selected = true
                    }
            };
        }
    }

    public class ViewModel
    {
        public IList<String> Data { get; set; }
        public ViewModel()
        {
            Data = new ObservableCollection<string>();
            Data.Add("Hello");
            Data.Add("World");
        }
    }

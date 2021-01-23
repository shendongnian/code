    public class ViewModel
    {
        private string _path;
        public ViewModel()
        {
            Strings = new ObservableCollection<string>();
            for (int i = 0; i < 50; i++)
            {
                Strings.Add("Value " + i);
            }
        }
        public ObservableCollection<string> Strings { get; set; }
    }

    public class TabBindingViewModels
    {
        public TabBindingViewModels()
        {
            Items = new ObservableCollection<TabBindingViewModel>
                        {
                            new TabBindingViewModel(1),
                            new TabBindingViewModel(2),
                            new TabBindingViewModel(3),
                        };
        }
        public IEnumerable<TabBindingViewModel> Items { get; private set; }
    }
    public class TabBindingViewModel
    {
        public TabBindingViewModel() : this(0)
        {
        }
        public TabBindingViewModel(int n)
        {
            Header = "I'm the header: " + n.ToString(CultureInfo.InvariantCulture);
            Content = "I'm the content: " + n.ToString(CultureInfo.InvariantCulture);
        }
        public string Header { get; set; }
        public string Content { get; set; }
    }

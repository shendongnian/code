    public class MainViewModel : ViewModelBase
    {
        public IEnumerable<MyItem> Items { get; private set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            Items = new List<MyItem>
                        {
                            new MyItem{ ISBN = "ISBN", BookName = "Book", PublisherName = "Publisher"}
                        };
            ClickMeCommand = new RelayCommand<MyItem>(ClickMe);
        }
        private void ClickMe(MyItem item)
        {
            Debug.WriteLine(string.Format("This book was clicked: {0}", item.BookName));
        }
        public ICommand ClickMeCommand { get; set; }

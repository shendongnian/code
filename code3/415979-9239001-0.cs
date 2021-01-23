    public class MyItem : ViewModelBase
    {
        public MyItem()
        {
            ClickMeCommand = new RelayCommand(ClickMe);
        }
        private void ClickMe()
        {
            Debug.WriteLine("I was clicked");
        }
        public string ISBN { get; set; }
        public string BookName { get; set; }
        public string PublisherName { get; set; }
        public ICommand ClickMeCommand { get; set; }
    }

    public partial class ThreeColumnChatSample : Window
    {
        public ChatViewModel ViewModel { get; set; }
        public ThreeColumnChatSample()
        {
            InitializeComponent();
            DataContext = ViewModel = new ChatViewModel();
        }
        private void Send_Click(object sender, RoutedEventArgs e)
        {
            InputBox.UpdateDocumentBindings();
            var entry = ViewModel.AddEntry();
            
            ListView.ScrollIntoView(entry);
        }
    }

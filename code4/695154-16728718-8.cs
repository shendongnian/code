    public partial class DataTemplateWindow : Window {
        public DataTemplateWindow() {
            DisplayText = "Some*Text*With*Separators";
            string [] splittedTextArray = DisplayText.Split('*');
            TextBlock0 = splittedTextArray[0];
            TextBlock1 = splittedTextArray[1];
            TextBlock2 = splittedTextArray[2];
            ListBoxItems = new List<string>();
            ListBoxItems.Add("Item 1");
            InitializeComponent();
            this.DataContext = this;
        }
        public string DisplayText { get; set; }
        public string TextBlock0 { get; set; }
        public string TextBlock1 { get; set; }
        public string TextBlock2 { get; set; }
        public List<string> ListBoxItems { get; set; }
    }

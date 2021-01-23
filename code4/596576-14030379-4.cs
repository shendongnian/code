    public partial class MainPage : PhoneApplicationPage
    {
        TextBlock textBlock1 = null;
        List<TextBlock> listText = null;
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            
            Contacts contact = new Contacts();
            contact.SearchAsync("", FilterKind.DisplayName, null);
            contact.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contact_SearchCompleted);
        }
        void contact_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            ContactList.DataContext = new ListViewModal(e.Results);
        }
        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchVisualTree(ContactList);
        }
        private void SearchVisualTree(DependencyObject targetElement)
        {
            var count = VisualTreeHelper.GetChildrenCount(targetElement);
            for (int i = 0; i < count; i++)
            {
                var child = VisualTreeHelper.GetChild(targetElement, i);
                if (child is TextBlock)
                {
                    textBlock1 = (TextBlock)child;
                    HighlightText();
                    break;
                }
                else
                {
                    SearchVisualTree(child);
                }
            }
        }
        private void HighlightText()
        {
            if (textBlock1 != null)
            {
                string text = textBlock1.Text;
                textBlock1.Text = text;
                textBlock1.Inlines.Clear();
                int index = text.IndexOf(textBox1.Text);
                int lenth = textBox1.Text.Length;
                if (!(index < 0))
                {
                    Run run = new Run() { Text = text.Substring(index, lenth), FontWeight = FontWeights.ExtraBold };
                    run.Foreground = new SolidColorBrush(Colors.Orange);
                    textBlock1.Inlines.Add(new Run() { Text = text.Substring(0, index), FontWeight = FontWeights.Normal });
                    textBlock1.Inlines.Add(run);
                    textBlock1.Inlines.Add(new Run() { Text = text.Substring(index + lenth), FontWeight = FontWeights.Normal });
                    textBlock1.FontSize = 30;
                    textBlock1.Foreground = new SolidColorBrush(Colors.Black);
                }
                else
                {
                    textBlock1.Text = "No Match";
                }
            }
        }
        private void ContactList_Loaded(object sender, RoutedEventArgs e)
        {
            
        }
    }

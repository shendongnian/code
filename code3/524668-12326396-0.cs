    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var items = new List<MyItem>
            {
                new MyItem { Foo = "Hello", Bar = "World" },
                new MyItem { Foo = "Just an", Bar = "Example" }
            };
            MyListView.ItemsSource = items;
            var str = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\">" +
                    "<Border Background=\"Blue\" BorderBrush=\"Green\" BorderThickness=\"2\">" +
                        "<StackPanel Orientation=\"Vertical\">" +
                            "<TextBlock Text=\"{Binding Foo}\"/>" +
                            "<TextBlock Text=\"{Binding Bar}\"/>" +
                        "</StackPanel>" +
                    "</Border>" +
                "</DataTemplate>";
            DataTemplate template = (DataTemplate)Windows.UI.Xaml.Markup.XamlReader.Load(str);
            MyListView.ItemTemplate = template;
        }
    }
    public class MyItem
    {
        public string Foo { get; set; }
        public string Bar { get; set; }
    }

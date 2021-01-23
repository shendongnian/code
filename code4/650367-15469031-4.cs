    namespace WpfApplication17
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                for (int i = 0; i < 20; i++)
                {
                    TestData.Add(new TestClass { MyProperty = GetRandomText(), MyProperty2 = GetRandomText(), MyProperty3 = GetRandomText() });
                }
            }
    
            private string GetRandomText()
            {
                return System.IO.Path.GetFileNameWithoutExtension(System.IO.Path.GetRandomFileName());
            }
            
            private ObservableCollection<TestClass> _testData = new ObservableCollection<TestClass>();
            public ObservableCollection<TestClass> TestData
            {
                get { return _testData; }
                set { _testData = value; }
            }
        }
    
        public class TestClass
        {
            public string MyProperty { get; set; }
            public string MyProperty2 { get; set; }
            public string MyProperty3 { get; set; }
        }
    
        public static class DataGridTextSearch
        {
            // Using a DependencyProperty as the backing store for SearchValue.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty SearchValueProperty =
                DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits));
    
            public static string GetSearchValue(DependencyObject obj)
            {
                return (string)obj.GetValue(SearchValueProperty);
            }
    
            public static void SetSearchValue(DependencyObject obj, string value)
            {
                obj.SetValue(SearchValueProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for IsTextMatch.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty IsTextMatchProperty =
                DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool), typeof(DataGridTextSearch), new UIPropertyMetadata(false));
    
            public static bool GetIsTextMatch(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsTextMatchProperty);
            }
    
            public static void SetIsTextMatch(DependencyObject obj, bool value)
            {
                obj.SetValue(IsTextMatchProperty, value);
            }
        }
    
        public class SearchValueConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
            {
                string cellText = values[0] == null ? string.Empty : values[0].ToString();
                string searchText = values[1] as string;
    
                if (!string.IsNullOrEmpty(searchText) && !string.IsNullOrEmpty(cellText))
                {
                    return cellText.ToLower().StartsWith(searchText.ToLower());
                }
                return false;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
            {
                return null;
            }
        }
    }

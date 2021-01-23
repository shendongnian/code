    namespace WpfApplication10
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
             
            }
        
            public IEnumerable<TestClass> TestData
            {
                get
                {
                    yield return new TestClass { Column1 = "Stack", Column2 = "Overflow" };
                    yield return new TestClass { Column1 = "Is", Column2 = "An" };
                    yield return new TestClass { Column1 = "Awesome", Column2 = "Resource" };
                }
            }
        }
    
    
        public static class DataGridTextSearch
        {
            public static readonly DependencyProperty SearchValueProperty =
                DependencyProperty.RegisterAttached("SearchValue", typeof(string), typeof(DataGridTextSearch),
                    new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.Inherits, new PropertyChangedCallback(PropertyChangedCallback)));
    
            private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
            {
                if (d is DataGrid)
                {
                    // serach text has changed, reset tag to false
                    (d as DataGrid).SetValue(IsAnyTextMatchProperty, false);
                }
            }
    
            public static string GetSearchValue(DependencyObject obj)
            {
                return (string)obj.GetValue(SearchValueProperty);
            }
    
            public static void SetSearchValue(DependencyObject obj, string value)
            {
                obj.SetValue(SearchValueProperty, value);
            }
    
    
            public static readonly DependencyProperty IsTextMatchProperty =
                DependencyProperty.RegisterAttached("IsTextMatch", typeof(bool),
                  typeof(DataGridTextSearch), new UIPropertyMetadata(false));
    
            public static bool GetIsTextMatch(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsTextMatchProperty);
            }
    
            public static void SetIsTextMatch(DependencyObject obj, bool value)
            {
                obj.SetValue(IsTextMatchProperty, value);
            }
    
            public static readonly DependencyProperty IsAnyTextMatchProperty =
             DependencyProperty.RegisterAttached("IsAnyTextMatch", typeof(bool),
               typeof(DataGridTextSearch), new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits));
    
            public static bool GetIsAnyTextMatch(DependencyObject obj)
            {
                return (bool)obj.GetValue(IsAnyTextMatchProperty);
            }
    
            public static void SetIsAnyTextMatch(DependencyObject obj, bool value)
            {
                obj.SetValue(IsAnyTextMatchProperty, value);
            }
        }
    
        public class SearchValueConverter : IMultiValueConverter
        {
            public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
            {
                string cellText = values[0] == null ? String.Empty : values[0].ToString();
                string searchText = values[1] as String;
                var datagrid = values[2] as DataGrid;
                bool returnvalue = false;
                if (!string.IsNullOrEmpty(searchText) &&
                    !string.IsNullOrEmpty(cellText))
                {
                    returnvalue = cellText.ToLower().StartsWith(searchText.ToLower());
                }
    
                // we found a match so mark DataGrid tag to true for use on TextBox
                if (returnvalue)
                {
                    datagrid.SetValue(DataGridTextSearch.IsAnyTextMatchProperty, true);
                }
                return returnvalue;
            }
    
            public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
            {
                throw new System.NotImplementedException();
            }
        }
    }

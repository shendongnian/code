    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            dataGrid1.ItemsSource = new List<TestClass>() { new TestClass() };
            dataGrid1.CellEditEnding += new EventHandler<DataGridCellEditEndingEventArgs>(dataGrid1_CellEditEnding);
    
            MouseDownHandler = new MouseButtonEventHandler((sender, args) => { args.Handled = true; });
            MouseClickHandler = new RoutedEventHandler((sender, args) => { args.Handled = true; });
        }
    
        private bool IsMouseEventStopped = false;
        private RoutedEventHandler MouseClickHandler = null;
        private MouseButtonEventHandler MouseDownHandler = null;
    
        void dataGrid1_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            bool correctCellValue = false;
            
            //correctCellValue = true to stop editing, if the cell value is correct
    
    
            if (correctCellValue)
            {
                // unblock mouse events
                if (IsMouseEventStopped == true)
                {
                    foreach (Button c in FindVisualChildren<Button>(this))
                        c.Click -= MouseClickHandler;
                    foreach (TextBox c in FindVisualChildren<TextBox>(this))
                        c.PreviewMouseLeftButtonDown -= MouseDownHandler;
                }
                IsMouseEventStopped = false;
            }
            else
            {
                e.Cancel = true;
                // block mouse events to certain controls
                if (IsMouseEventStopped == false)
                {
                    IsMouseEventStopped = true;
                    foreach (Button c in FindVisualChildren<Button>(this))
                        c.Click += MouseClickHandler;
                    foreach (TextBox c in FindVisualChildren<TextBox>(this))
                        c.PreviewMouseLeftButtonDown += MouseDownHandler;
                }
            }
        }
    
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                        yield return (T)child;
    
                    foreach (T childOfChild in FindVisualChildren<T>(child))
                        yield return childOfChild;
                }
            }
        }
    }

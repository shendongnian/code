    public partial class MainWindow : Window
    {
        public ObservableCollection<TestClass> Items
        {
            get { return (ObservableCollection<TestClass>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }
    
        public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<TestClass>), typeof(MainWindow), new PropertyMetadata(null));
    
        public MainWindow()
        {
            InitializeComponent();
            Items = new ObservableCollection<TestClass>();
            for (int i = 0; i < 100; i++)
                Items.Add(new TestClass()
                {
                    ID = i,
                    Text = "Text for row " + i.ToString()
                });
        }
    }
    
    public class RowStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            TestClass targetIem = item as TestClass;
            if (targetIem != null)
            {
                // You can work with your data here.
                if (targetIem.ID == 0)
                {
                    // Locate and return the style for when ID = 0.
                    return (Style)Application.Current.FindResource("ResourceName");
                }
                else
                    return base.SelectStyle(item, container);
            }
            else
                return base.SelectStyle(item, container);
        }
    }
    
    public class TestClass
    {
        public int ID { get; set; }
        public string Text { get; set; }
    }

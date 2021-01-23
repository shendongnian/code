    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Class> Classes
        {
            get { return (ObservableCollection<Class>)GetValue(ClassesProperty); }
            set { SetValue(ClassesProperty, value); }
        }
        public static readonly DependencyProperty ClassesProperty = DependencyProperty.Register("Classes", typeof(ObservableCollection<Class>), typeof(MainWindow), new UIPropertyMetadata(null));
    
        public MainWindow()
        {
            InitializeComponent();
    
            Class math = new Class()
            {
                ClassName = "Math 1412",
                Description = ""
            };
    
            Class physics = new Class()
            {
                ClassName = "Physics 1911",
                Description = "Everything everywhere anywhen",
            };
            physics.AddPre(math);
            Classes = new ObservableCollection<Class>();
            Classes.Add(math);
            Classes.Add(physics);
        }
    }

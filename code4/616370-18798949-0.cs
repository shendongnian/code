    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var t = Activator.CreateInstance(typeof(T), typeof(int)); // Missing constructor
            // or:
            //this.GetType().InvokeMember("NonExistingMember", BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod, null, this, new object[0]);
        }
    }
    
    public class T
    {}

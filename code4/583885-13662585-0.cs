    public partial class Window1 : Window
    {
        private SimpleObject so = new SimpleObject();
        public Window1()
        {
            InitializeComponent();
            this.so = new SimpleObject();
            so.Name = "Initial value";
            this.DataContext = so;
            var t = new DispatcherTimer(
                TimeSpan.FromSeconds(1), 
                DispatcherPriority.Normal,
                (s, e) => { this.so.Name = "Name changed at: " + DateTime.Now.ToString(); },
                Dispatcher);
        }
        private void changeNameClick(object sender, RoutedEventArgs e)
        {
            this.so.Name = "New value!!";
        }
    }
    public class SimpleObject
    {
        private string mName = null;
        public string Name 
        {
            get { return mName; }
            set
            {
                if (mName != value)
                {
                    mName = value;
                    if (NameChanged != null)
                        NameChanged(this, EventArgs.Empty);
                }
            }
        }
        public event EventHandler NameChanged;
    }

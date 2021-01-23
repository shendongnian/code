        public partial class UserControl1 : UserControl
    {
        public event EventHandler<EventArgs> CreateNewUserControl = null;
        public static int InstanceCount = 0;
        public UserControl1()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(UserControl1_Loaded);
        }
        void UserControl1_Loaded(object sender, RoutedEventArgs e)
        {
            InstanceCount++;
            txtControl.Text = "Control - " + InstanceCount;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var handler = CreateNewUserControl;
            if (handler != null)
             handler.Invoke(sender,e);
        }
    }

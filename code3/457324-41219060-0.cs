    public partial class MyUserControl: UserControl
    {
        public MyUserControl()
        {
            InitializeComponent();
            SizeChanged += UserControl_DoOnce; //register
        }
        private void UserControl_DoOnce(object sender, SizeChangedEventArgs e)
        {
            if (ActualHeight > 0)//Once the object has size, it has been rendered.
            {
                  SizeChanged -= UserControl_DoOnce; //Unregister so only done once
            }
        }
    }

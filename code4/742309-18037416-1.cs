    public partial class UserControls : System.Windows.Controls.UserControl
    {
        private SerialPortController ctrl;
        public UserControls()
        {
            InitializeComponent();
            // pass ImageViewModel from the UserControl's DataContext
            ctrl = new SerialPortController(DataContext as ImageViewModel);
        }
        //other code
        ctrl.OpenPort();
        //other code
        ctrl.ClosePort();
    }

    public class HomeForm
    {
        public HomeForm()
        {
            InitializeComponent();
        }
        private bool adminPermissions;  
        public bool AdminPermissions
        {
            get { return adminPermissions; }
            set { 
                adminPermissions = value;
                textBox1.Text = value.ToString();
            }
        }
        ...
    }

    public partial class CustomControl : UserControl
    {
        public CustomControl()
        {
            InitializeComponent();
        }
    
        public string ControlPath
        {
            get
            {
                return string.Join(@"\", this.GetControlPath().Reverse());
            }
        }
    }

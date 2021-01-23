         public delegate void OkClickedHandler(Object sender, EventArgs e);
    
    public partial class UserControl1 : UserControl
    {
        
        public event OkClickedHandler OkClick;
        public UserControl1()
        {
            InitializeComponent();
            
        }
        
        private void button3_Click(object sender, EventArgs e)
        {
            if (OkClick == null) return;
            OkClick(sender, e);
            
        }
    }

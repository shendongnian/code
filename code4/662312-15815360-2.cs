    namespace WindowsFormsApplication1
    {
        public partial class UserControl1 : UserControl
        {
            public event EventHandler OnButtonClicked;
    
    
            public UserControl1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                EventHandler handler = OnButtonClicked;
    
                // if something is listening for this event, let let them know it has occurred
                if (handler != null)
                {
                    handler(this, new EventArgs());
                }
    
            }
        }
    }
 
 

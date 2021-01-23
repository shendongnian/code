    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
       
        public event RoutedEventHandler Button1Click;
        
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if (Button1Click != null) Button1Click(sender, e);     
        }
    }

    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
            Flag flags = new Flag();          
            flags.Name = "1111"; 
            flags.Tag = "1";     
            flags.Save();        
        }
    }

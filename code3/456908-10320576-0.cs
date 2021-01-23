    namespace WpfApplication1
    {
        /// <summary>
        /// Interaction logic for OtherWindow.xaml
        /// </summary>
        public partial class OtherWindow : Window
        {
            public OtherWindow()
            {
                InitializeComponent();
            }
    
            public string SomeData
            {
                get
                {
                    //you'll probably want to return the value of a textbox or something else 
                    //the user fills in.
                    return "Hello World!";
                }
            }
        }
    }

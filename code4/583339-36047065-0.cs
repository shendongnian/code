    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            UI ui = null;
            //Here, "null" prevents an automatic instantiation of the class,
            //which may raise a Stack Overflow Exception or not.
            //If you're creating controls such as TextBoxes, Labels, Buttons... 
            public MainWindow()
            {
                InitializeComponent(); //This starts all controls created with the XAML Designer.
                ui = new UI(); //Now we can safely create an instantiation of our UI class.
                ui.Start();
            }
        }
    }

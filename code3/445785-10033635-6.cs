    namespace WpfApplication1
    {
        public partial class MainWindow : Window
        {
            private Foo foo;
            public MainWindow()
            {
                InitializeComponent();
                foo = new Foo();
                foo.Closed += FooClosed;
                foo.Show();
            }
            public void FooClosed(object sender, System.EventArgs e)
            {
                //This gets fired off
                foo = null;
            }
       
        }
    }

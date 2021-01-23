    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            try
            {
                DoSomething();
    
                // maybe something more if everything went ok
            }
            catch( InitializationException ex )
            {
                // log the exception
                Close();
            }
        }
        
        public void DoSomething()
        {
            if (notSomethingOK)
                throw new InitializationException( "Something is not OK and the applicaiton must shutdown." );
        }
    }

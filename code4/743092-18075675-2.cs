    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            var textBox = new TextBox();
            textBox.TextChanged += (o, e) => Console.WriteLine("External handler");
            var b = new B(textBox);
            textBox.Text = "foo";
            b.MakeProblem();
        }
    }
    
    class B
    {
        private TextBox _a;
        bool _dontDoThis;
        public B(TextBox a)
        {
            _a = a;
            a.InsertEventHandler(0, TextBox.TextChangedEvent, new TextChangedEventHandler(Handler));
        }
        void Handler(object sender, TextChangedEventArgs e)
        {
            Console.WriteLine("B.Handler");
            e.Handled = _dontDoThis;
            if (_dontDoThis)
            {
                e.Handled = true;
                return;
            }
            // do this!
        }
        public void MakeProblem()
        {
            try
            {
                _dontDoThis = true;
                _a.Text = "make a problem";
            }
            finally
            {
                _dontDoThis = false;
            }
            
        }
    }
    

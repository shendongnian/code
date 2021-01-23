    public partial class Form1 : Form
    {
        Timer _timer = new Timer();
        [ThreadStatic]
        bool inEvent = false;
    
        public Form1()
        {
            InitializeComponent();
    
            _timer.Tick += delegate { DoSomething(); };
            _timer.Interval = 5000;
            _timer.Start();
        }
    
        private void DoSomething()
        {
            // if you want to stay here and wait instead of exiting, you could do:
            // while (inEvent);
            if (!inEvent)
            {
                inEvent = true;
                Form2 form2 = new Form2();
                form2.ShowDialog();
                inEvent = false;
            }
        }
    }

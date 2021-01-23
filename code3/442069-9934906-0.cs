    public partial class Form1 : Form
    {
        Timer _timer = new Timer();
        Form2 form2 = new Form2();
    
        public Form1()
        {
            InitializeComponent();
    
            _timer.Tick += delegate { DoSomething(); };
            _timer.Interval = 5000;
            _timer.Start();
        }
    
        private void DoSomething()
        {
            if(!form2.Visible)
            {
               form2.ShowDialog();
            }
        }
    }

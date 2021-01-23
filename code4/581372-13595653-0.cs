    public partial class Form1 : Form
    {
        Dictionary<string, EventHandler> map;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000;
            //timer.Tick += new EventHandler(timer_Tick);
            map = new Dictionary<string, EventHandler>();
            map["1"] = timer_Tick;
            timer.Tick += map["1"];
        }
        void timer_Tick(object sender, EventArgs e)
        {
            //do what you need            
        }
    }

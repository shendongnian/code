     public partial class MainForm : Form
     {
        public MainForm()
        {
            InitializeComponent();
        }
        RMouseListener _native;
        private void button1_Click(object sender, EventArgs e)
        {//start
            _native = new RMouseListener();
            _native.RButtonClicked += 
                 new EventHandler<SysMouseEventInfo>(_native_RButtonClicked);
        }
        private void button2_Click(object sender, EventArgs e)
        {//stop
            _native.Close();
        }
        void _native_RButtonClicked(object sender, SysMouseEventInfo e)
        {
            listBox1.Items.Add(e.WindowTitle);
        }
        
    }

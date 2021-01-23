    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        private WMPLib.WindowsMediaPlayer wplayer = new WMPLib.WindowsMediaPlayer();
        public Form1()
        {
            InitializeComponent();
            string path = "C:\\Users\\Public\\Music\\Sample Music\\Kalimba.mp3";
            wplayer.URL = path;
            wplayer.controls.play();
            timer.Interval = 2000;
            timer.Tick += timer_Tick;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Process[] processes = Process.GetProcesses();
            Debug.WriteLine(processes.Length + " running processes");
        }
    }

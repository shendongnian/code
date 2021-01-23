    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        private FileStream fs;
        private StreamWriter sw
    
        public Service1()
        {
            InitializeComponent();
        }
    
        protected override void OnStart(string[] args)
        {
            fs = new FileStream(@"D:\Hello.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            sw = new StreamWriter(fs);
            timer = new Timer();
            timer.Elapsed += new ElapsedEventHandler(WriteText);
            timer.Interval = 5000; //5 seconds
            timer.Start();
        }
    
        public void WriteText(object source, ElapsedEventArgs e)
        {
            sw.WriteLine(DateTime.Now + " Windows Service");
        }
        protected override void OnStop()
        {
            timer.Stop(); // Stop the timer before closing the file
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();
        }
    }

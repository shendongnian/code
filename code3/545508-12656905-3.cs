    public partial class Form1 : Form
    {
        delegate void FormUpdateDelegate(object sender, ElapsedEventArgs e);
        public BackgroundWorker backgroundThread; 
        System.Timers.Timer foo;
        Random colorgen = new Random();
        public Form1()
        {
            InitializeComponent();
    
            backgroundThread = new BackgroundWorker();
            backgroundThread.DoWork+=new DoWorkEventHandler(backgroundThread_DoWork);
            backgroundThread.RunWorkerAsync();
        }
    
        public void formUpdater(object sender, ElapsedEventArgs e)
        {
            if (InvokeRequired)
            {
                FormUpdateDelegate d = new FormUpdateDelegate(formUpdater);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                // Do your form update here
                this.label1.ForeColor = Color.FromArgb(colorgen.Next());
            }
        }
    
        public void backgroundThread_DoWork(object sender, DoWorkEventArgs e)
        {
            foo = new System.Timers.Timer(16);
            foo.Elapsed += new ElapsedEventHandler(formUpdater);
            foo.Start();
        }
    
    }

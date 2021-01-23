          namespace ICAMReports
    {
    public partial class Form1 : Form
    {
        ManualResetEventSlim splashDone = new ManualResetEventSlim(false);
        public Form1()
        {
            InitializeComponent();
            Thread th = new Thread(new ThreadStart(splashScreen));
            th.Start();
            splashDone.Wait();
        }
        public void splashScreen()
        {
            Application.Run(new SplashScreen(splashDone));
        }
       //this where the rest of code is placed....
        }
        }

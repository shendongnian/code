        namespace ICAMReports
    {
    public partial class SplashScreen : Form
    {
        ManualResetEventSlim splashDone;
        public SplashScreen(ManualResetEventSlim SplashDone)
        {
         splashDone=SplashDone;
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                splashDone.Set();
                this.Close();
            } } } }
     

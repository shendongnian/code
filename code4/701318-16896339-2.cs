        namespace ICAMReports
    {
    public partial class SplashScreen : Form
    {
        Form parent;
        delegate void show();
        public SplashScreen(Form Parent)
        {
         parent=Parent;
            InitializeComponent();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);
            if (progressBar1.Value == 100)
            {
                parent.Invoke(new show(()=>{parent.Opacity=100;}));
                this.Close();
            } } } }
     

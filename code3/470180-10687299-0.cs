    static class Program
    {
        [STAThread]
        static void Main()
        {
            using (SplashScreen sp = new SplashScreen())
            {
                sp.StartPosition = FormStartPosition.CenterScreen;
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1()); 
                }
            }
        }
    }
    
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
            DoTheWork();
        }
        private void DoTheWork()
        {
            //...
            //and on the end
            this.DialogResult = DialogResult.OK;
        }
    }

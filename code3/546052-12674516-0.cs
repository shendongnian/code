    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Application.DoEvents();            
        }
        public void SetProgress(int value)
        {
            progressBar1.Value=value;
        }
        public void SetProgress(int value, int max)
        {
            progressBar1.Maximum=max;
            progressBar1.Value=value;            
        }
        public void Increment()
        {
            progressBar1.PerformStep();
        }
    }

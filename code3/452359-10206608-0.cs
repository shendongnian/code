    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            this.myCustomControlInstanse.PicureBoxMouseMove += new EventHandler<StringEventArgs>(myCustomControlInstanse_PicureBoxMouseMove);
        }
        private void myCustomControlInstanse_PicureBoxMouseMove(object sender, StringEventArgs e)
        {
            this.MouseCordsDisplayLabel = e.Value // here is your value
        }
    }
    public class StringEventArgs : EventArgs
    {
        public string Value { get; set; }
    }
    public partial class ScoreUserControl : UserControl
    {
        public event EventHandler<StringEventArgs> PicureBoxMouseMove;
        public void OnPicureBoxMouseMove(String value)
        {
            if (this.PicureBoxMouseMove != null)
                this.PicureBoxMouseMove(this, new StringEventArgs { Value = value });
        }
        public ScoreUserControl()
        {
            InitializeComponent();
        }
        private void ScorePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnPicureBoxMouseMove("Some Text Here");
        }
    }

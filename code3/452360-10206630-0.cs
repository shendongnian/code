        public partial class ScoreUserControl : UserControl
    {
        public ScoreUserControl()
        {
            InitializeComponent();
        }
    
        private void ScorePictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            // MainForm.MouseCords("Hello"); //What goes here?
            MainForm parent = this.ParentForm as MainForm;
            if (parent != null) parent.MouseCordsDisplayLabel.Text = "Hello";
        }
    }

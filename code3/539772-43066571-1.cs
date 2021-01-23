    public partial class AdvancedForm : Form
    {
        Fader fader;
        public AdvancedForm()
        {
            InitializeComponent();
        }
        private void MyForm_Load(object sender, EventArgs e)
        {
            Fader.FadeIn(this, Fader.FadeSpeed.Normal);
        }
    }

    public partial class myForm : Form
    {
        public myForm()
        {
            InitializeComponent();
        }
        private void myForm_Load(object sender, EventArgs e)
        {
            KeyPreview = true;
            KeyUp += (s, ek) =>
                         {
                             if (ek.KeyCode == Keys.V && ModifierKeys.HasFlag(Keys.Control))
                                 MessageBox.Show("Yerp, it done happened");
                         };
        }
    }

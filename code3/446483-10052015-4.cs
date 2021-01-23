    public partial class Form2 : Form
    {
        Color newColor;
        public Form2()
        {
            InitializeComponent();
        }
        public Color formColor
        {
            get { return this.newColor; }
            set { this.newColor = value; }
        }
        private void btnRed_Click(object sender, EventArgs e)
        {
            newColor = Color.Red;
        }
        private void btnBlue_Click(object sender, EventArgs e)
        {
            newColor = Color.Blue;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
        } 
    }

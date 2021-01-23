    1. Set the object of the Overlay  to a property in Child Window
    2. And in the Form_Closing event of the child window, close the Overlay window.
    public partial class ChildForm : Form
    {
		//This is set in the Parent form where the child form instatce is created
        public Form OverLay { get; set; }
        public ChildForm()
        {
            InitializeComponent();
        }
        private void ChildForm_Load(object sender, EventArgs e)
        {
        }
        private void ChildForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.OverLay.Close();
        }
    }

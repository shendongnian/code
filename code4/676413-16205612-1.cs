    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            userControl11.ClassificationClicked += new EventHandler(userControl11_ClassificationClicked);
        }
        void userControl11_ClassificationClicked(object sender, EventArgs e)
        {
            classification control = new classification();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(control);
        }
    }

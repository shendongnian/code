    public partial class formMain : Form
    {
        Static staticControl;
        Classification classificationControl;
        public formMain()
        {
            InitializeComponent();
            staticControl= new Static();
            panelSide.Controls.Clear();
            panelSide.Controls.Add(staticControl);
            staticControl.ClassificationClicked += new EventHandler(Static_ClassificationClicked); 
        }
        void  Static_ClassificationClicked(object sender, EventArgs e)
        {
            classificationControl = new classification();
            panelMain.Controls.Clear();
            panelMain.Controls.Add(classificationControl);
        }
    }

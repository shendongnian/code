    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // your usercontrol
            userControl11.clicked += userControl11_clicked;
        }
        void userControl11_clicked(object sender, EventArgs e)
        {
            
        }
    }

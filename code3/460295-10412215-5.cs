    public partial class formEdit : Form
    {
        // Define a MyDataCollection object to work with in **this** form
        MyDataCollection myData;
        public formEdit(MyDataCollection mdc)
        {
            InitializeComponent();
            
            // Get the MyDataCollection instance sent as parameter
            myData = mdc;
        }
        private void formEdit_Load(object sender, EventArgs e)
        {
            // and use it to show the data
            textbox1.Text = myData.Name;
            textbox2.Text = myData.Email;
            // --
        }
    }

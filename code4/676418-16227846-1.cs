    public partial class UserControl1 : UserControl
    {
        public event EventHandler ClassificationClicked;
        public UserControl1()
        {
            InitializeComponent();
        }
    
        private void btnClassification_Click(object sender, EventArgs e)
        {
            RaiseClassifactionClicked();
        }
    
        private RaiseClassifactionClicked()
        {
            var tmp = ClassificationClicked; //This is added for thread safty
            if(tmp != null) //check to see if there are subscribers, if there are tmp will not be null
               tmp(this, EventArgs.Empty); //You don't need to pass along the sender and e, make your own here.
        }
    }

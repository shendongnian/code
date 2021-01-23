    public partial class customerHistory : Form
    {
        private string passtexboxvaluetoclass = "";   
        // load class dependant.cs
        dependents cls_dependents = new dependents();
        public customerHistory()
        {
            InitializeComponent();
        }
    private void button1_Click(object sender, EventArgs e)
        {
            dependents.passtexboxvaluetoclass = textbox1.text;
            // load next form
        }

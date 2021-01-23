    public partial class Form1 : Form
    {
        private string dataFromThisForm; //can be whatever
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 otherForm = new Form2();
            //pass some data to other form
            otherForm.SomeData = dataFromThisForm; 
    
            this.Hide();
            otherForm.Show();
    
            //when the other form is closed
            otherForm.FormClosed += (sender2, e2) =>
            {
                this.Show();
    
                string newData = otherForm.NewData;
            };
    
            //when the other form is hidden.
            otherForm.VisibleChanged += (sender2, e2) =>
            {
                this.Show();
    
                string newData = otherForm.NewData;
            };
        }
    }
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            //Use SomeData to populate controls.
        }
    
        public string SomeData { get; set; } //data passed in from other form
    
        public string NewData { get; private set; }  //data to expose to other form
        private void button1_Click(object sender, EventArgs e)
        {
            NewData = "SomeDataToPassToForm1";
            //this.Close();
            this.Hide();
        }
    }

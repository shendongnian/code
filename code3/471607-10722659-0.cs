    namespace PassingDataExample
    {
        public partial class ParentForm : Form
        {
            public ParentForm()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                ChildForm child = new ChildForm();
                child.DataFromParent = "hello world";
    
                child.FormSubmitted += (sender2, arg) =>
                {
                    child.Close();
    
                    string dataFromChild = child.DataFromChild;
                };
    
                child.Show();
            }
        }
    }
    namespace PassingDataExample
    {
        public partial class ChildForm : Form
        {
            public ChildForm()
            {
                InitializeComponent();
            }
    
            public string DataFromParent { get; set; }
    
            public string DataFromChild { get; private set; }
    
            public event EventHandler FormSubmitted;
    
            private void button1_Click(object sender, EventArgs e)
            {
                DataFromChild = "Hi there!";
    
                if (FormSubmitted != null)
                    FormSubmitted(this, null);
            }
        }
    }

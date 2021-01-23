 	1. Create an instance of the Child form 
	2. Create an Instance of the Overlayform, Pass the objects Instances of Child and Parent(current form) as a parameter to the Constructor
    3. Then Show the OverLay Form by using 	ShowDialog Method.
	
	Code:
   
    public partial class ParentForm : Form
    {
        public ParentForm()
        {
            
            InitializeComponent();
        }
        private void ParentForm_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            ChildForm child1 = new ChildForm();
            // Create a new form.
            OverlayForm form2 = new OverlayForm(this, child1);
            child1.OverLay = form2;
            // Display the form as a modal dialog box.
            form2.ShowDialog(this);
        }
    }
	

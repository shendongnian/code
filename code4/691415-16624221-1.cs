    public partial class UpdateForm : Form
    {
        private SystemForm.dSearch _target;
        public UpdateForm(string selectedPerson, string dbdirec, string dbfname, SystemForm.dSearch target)
        {
            _target = target;
            InitializeComponent();
        }
        private void updateButton_Click(object sender, EventArgs e)
        {
            //do stuff
            _target();
            this.Close();
        }
    }

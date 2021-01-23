    public event SearchEventHandler OnSearch;
    namespace SalesSystem
    {
    public delegate void SearchEventHandler(string searchParameter); 
        public partial class UpdateForm : Form
        {
            public UpdateForm(string selectedPerson, string dbdirec, string dbfname)
            {
                InitializeComponent();
    
            }
    
            private void updateButton_Click(object sender, EventArgs e)
            {
                //do stuff
    
                SystemForm parent = (SystemForm)this.Owner;
                parent.searchButton.PerformClick();
    
                this.Close();
            }
        }
    }

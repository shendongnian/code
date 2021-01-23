    namespace SalesSystem
    {
        public partial class SystemForm : Form
        {
            public SystemForm()
            {
                InitializeComponent();
            }    
    
            protected void searchButton_Click(object sender, EventArgs e)
            {
               //search code
            }
    
            private void updateButton_Click(object sender, EventArgs e)
            {
                try
                {
                    UpdateForm upForm = new UpdateForm(resultBox.SelectedItems[0].Text,            dbdirec, dbfname);
                    upForm.OnSearch += Search;                      
                    upForm.ShowDialog(this);
                }
                catch (Exception)
                {
                    //
                }
            }
            
            private void Search(string searchParameter)
            {
                ....
            }
        }
    namespace SalesSystem
    {
        public delegate void SearchEventHandler(string searchParameter); 
        public partial class UpdateForm : Form
        {
         
            public event SearchEventHandler OnSearch;
            
            public UpdateForm(string selectedPerson, string dbdirec, string dbfname)
            {
                InitializeComponent();
    
            }
    
            private void updateButton_Click(object sender, EventArgs e)
            {
                //do stuff
    
                OnSearch("SearchThis");
    
                this.Close();
            }
        }
    }

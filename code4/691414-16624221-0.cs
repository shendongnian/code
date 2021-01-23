        public partial class SystemForm : Form
        {
            public delegate void dSearch();
            public SystemForm()
            {
                InitializeComponent();
            }
            protected void searchButton_Click(object sender, EventArgs e)
            {
                search();
            }
            private void search()
            {
                //search code
            }
            private void updateButton_Click(object sender, EventArgs e)
            {
                try
                {
                    UpdateForm upForm = new UpdateForm(resultBox.SelectedItems[0].Text, dbdirec, dbfname, search);
                    upForm.ShowDialog(this);
                }
                catch (Exception)
                {
                    //
                }
            }
        }

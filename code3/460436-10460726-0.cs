    public class MySearchForm
    {
    public string SelectedSID { get; private set;}
    // code to show a list of Students and StudentsIDs.
    }
    
    public class myMainForm
    {
        public void SearchButton_Click(object sender, EventArgs ea)
        {
            using(MySearchForm searchForm = new MySearchForm())
            {
                if(DialogResult.OK == searchForm.ShowDialog())
                {
                     mySutdentIDTextBox.Text = searchForm.SelectedSID;
                }
            }
        }
    }

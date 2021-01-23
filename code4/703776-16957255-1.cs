    public void btnSave_Click(object sender, EventArgs e)
    {
         if (cmbMyList.SelectedIndex.CompareTo(n) == 0) // n - your empty value index
         {
             MessageBox.Show("Selected value is not valid.");
         }
         else
         {
             // proceed
         }
    }

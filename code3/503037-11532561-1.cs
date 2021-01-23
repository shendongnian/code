        private void FilterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selText = FilterComboBox.SelectedValue.ToString();         
            FillGrid(selText);
        }
   
       private void FillGrid(string filterValue = "0")
       {
            //GetDefaultValues(if filtervalue = 0)
            //else GetValues(based On Selected category)
            //Bind Values to Grid
       }

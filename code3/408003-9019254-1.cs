    // To Load (after combo box binding / population)
    private void LoadSelection()
    {
        int selectedIndex = 0;
        if (int.TryParse(Properties.Settings.Default.comboBoxSelection, out selectedIndex))
        {
            cbMyComboBox.SelectedIndex = selectedIndex;
        }
    }
    // saving on button click.
    private void saveButton_Click(object sender, EventArgs e)  
    {  
        //set the new value of comboBoxSelection 
        Properties.Settings.Default.comboBoxSelection = cbMyComboBox.SelectedIndex;  
      
        //apply the changes to the settings file  
        Properties.Settings.Default.Save();  
    }  

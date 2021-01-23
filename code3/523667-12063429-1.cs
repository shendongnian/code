    private void LstBox_HealthyCat_SelectedIndexChanged(object sender, System.EventArgs e)
    {
       // Get the currently selected item in the ListBox. 
       string curCategory = LstBox_HealthyCat.SelectedItem.ToString();
       string[] subCatItems = GetFileContent(curCategory).Split(','); 
    
       // Clear the previous list of foods from the second listbox
       ListSubCategory.Items.Clear();
       ListSubCategory.Items.AddRange(subCatItems); 
    }

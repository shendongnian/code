    //initilize List and put current selected index in it
    List<int> previousScreen = new List<int>();
    previousScreen.Add(RegionComboBox.SelectedIndex);    
    //Button Event
     private void prevB_Click(object sender, EventArgs e)
        {
            if (previousScreen.Count >= 2)
            {
                RegionComboBox.SelectedIndex = previousScreen[previousScreen.Count - 2];
            }
        }

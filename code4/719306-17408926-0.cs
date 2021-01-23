    private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        //Submit clicked Entry
        try
        {
            if(listBox1.SelectedItem is Harvest_TimeSheetEntry)
            {
                Harvest_TimeSheetEntry entryToPost = (Harvest_TimeSheetEntry)listBox1.SelectedItem;
                if (!entryToPost.isSynced)
                {
                    //Check if something is selected in selectedProjectItem For that item
                    if (entryToPost.ProjectNameBinding == "Select Project" && entryToPost.ClientNameBinding == "Select Client")
                        MessageBox.Show("Please select you Project and Client");
                    else
                        Globals._globalController.harvestManager.postHarvestEntry(entryToPost);
                        MessageBox.Show("Entry posted");
                        entryToPost.IsInEditMode = true; //set edit mode!
                }
            }
            else
            {
                //Already synced.. Make a noise or something
                MessageBox.Show("Already Synced;TODO Play a Sound Instead");
            }
        }
        catch (Exception)
        { }
     }

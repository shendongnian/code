    private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //Submit clicked Entry
            try
            {
                ListBoxItem item = (ListBoxItem)sender;
                Harvest_TimeSheetEntry entryToPost = (Harvest_TimeSheetEntry)item.Content;
                if (!entryToPost.isSynced)
                {
                    //Check if something is selected in selectedProjectItem For that item
                    if (entryToPost.ProjectNameBinding == "Select Project")
                        MessageBox.Show("Please Select a Project for the Entry");
                    else
                        Globals._globalController.harvestManager.postHarvestEntry(entryToPost);
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

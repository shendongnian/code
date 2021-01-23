    private void EditButton_Click(object sender, RoutedEventArgs e)
    {
        foreach (Harvest_TimeSheetEntry item in listBox1.Items)
        {
            if (item.isSynced)
            {
                item.Reset();
                item.isSynced = false;
                listBox1.ItemTemplate = (DataTemplate)this.FindResource("EditableDataTemplate");
                this.EditButton.Content = "Done Editing";
            }
            else
            {
                listBox1.ItemTemplate = (DataTemplate)this.FindResource("DefaultDataTemplate");
                this.EditButton.Content = "Edit";
                if(item.DirtyFlag)
                {
                    Globals._globalController.harvestManager.postHarvestEntry(item);
                    item.Reset();
                    System.Windows.MessageBox.Show("Entry posted");
                }
            }
        }
    }

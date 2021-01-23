    OnRemoveButtonClickHandler()
    {
        listXuid.Items.Remove(listXuid.SelectedItem);
        // open the file for overwriting
        foreach (var item in listXuid.Items)
        {
            // write out each item in your format
        }
    }

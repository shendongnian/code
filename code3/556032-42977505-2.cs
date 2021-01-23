    public void SelectFile(String fname)
    {
        foreach (dynamic item in cmbModules.Items)
        {
            if (item.Filename == fname)
            {
                cmbModules.SelectedItem = item;
                break;
            }
        }
    }

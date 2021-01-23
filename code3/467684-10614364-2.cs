    foreach (MyItem item in listBoxZone.Items)
    {
        if ((bool)item.IsChecked) // cast Nullable<bool> to bool
        {
            ...
        }
    }

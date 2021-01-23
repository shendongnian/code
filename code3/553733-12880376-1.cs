    for (int i = 0; i < grd.Items.Count; i++)
    {
       DataGridRow row = (DataGridRow)grd.ItemContainerGenerator.ContainerFromIndex(i);
       CheckBox checkBox = FindChild<CheckBox>(row, "chb");
       if( checkBox != null && checkBox.IsChecked == true )
       {
           //some code
       }
    }

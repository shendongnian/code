    private void SelectAll()
        {
            for (int i = 0; i < dgVehicle.Items.Count; i++)
            {
                DataGridRow row = (DataGridRow)dgVehicle.ItemContainerGenerator.ContainerFromIndex(i);
                if (row != null)
                {
                    CheckBox chk = dgVehicle.Columns[0].GetCellContent(row) as CheckBox;
                    chk.IsChecked = true;
                }
            }
        } 

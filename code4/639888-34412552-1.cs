    private void ItemContainerGenerator_StatusChanged(object sender, EventArgs e)
        {
            if (grid.ItemContainerGenerator.Status == System.Windows.Controls.Primitives.GeneratorStatus.ContainersGenerated)
            {
                int index = grid.SelectedIndex;
                if (index >= 0)
                {
                    var row = grid.ItemContainerGenerator.ContainerFromIndex(index) as DataGridRow;
                    if (row != null)
                    {
                        row.Focus();
                        FocusManager.SetIsFocusScope(row, true);
                        FocusManager.SetFocusedElement(row, row);
                    }
                        
                }
            }
        }

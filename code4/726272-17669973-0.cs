        private void Plan_PreviewMouseRightButtonDownCmd_Execute(MouseButtonEventArgs e)
        {
            ComboBox comboBox =  e.Source as ComboBox;
            if(comboBox!=null)
            {
                foreach (IPlan item in comboBox.Items)
                {
                    ComboBoxItem cbi = comboBox.ItemContainerGenerator.ContainerFromItem(item) as ComboBoxItem;
                    if (cbi.IsHighlighted == true)
                    {
                        SelectedPlans.Remove(item);
                        return;
                    }
                }
            }
        }

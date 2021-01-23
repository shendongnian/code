    myComboBox.ItemContainerGenerator.StatusChanged += ItemContainerGenerator_StatusChanged;
    void ItemContainerGenerator_StatusChanged(object sender, System.EventArgs e)
    {
        if (myComboBox.ItemContainerGenerator.Status == GeneratorStatus.ContainersGenerated)
        {
            foreach (var item in myComboBox.Items)
            {
                var container = (ComboBoxItem)LanguageComboBox.ItemContainerGenerator.ContainerFromItem(item);
            }
        }
    }

    private void ComboBoxSelect(ComboBox comboBox, object valueToSelect)
    {
        for (int i = 0; i < comboBox.Items.Count; i++)
        {
            object item = comboBox.Items[i];
            object valor = item.GetType().GetProperty("Key").GetValue(item, null);
            if (Convert.ToString(valor) == Convert.ToString(valueToSelect))
            {
                comboBox.SelectedIndex = i;
                return;
            }
        }
        comboBox.SelectedIndex = -1;
    }

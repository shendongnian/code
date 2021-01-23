    // Set ComboBox.SelectedValue
    private void ComboBoxSelectedValue(ComboBox comboBox, object valueToSelect)
    {
        for (int i = 0; i < comboBox.Items.Count; i++)
        {
            object item = comboBox.Items[i];
            object value = item.GetType().GetProperty("Key").GetValue(item, null);
            if (Convert.ToString(value) == Convert.ToString(valueToSelect))
            {
                comboBox.SelectedIndex = i;
                return;
            }
        }
        comboBox.SelectedIndex = -1;
    }
    // Get ComboBox.SelectedValue
    private object ComboBoxSelectedValue(ComboBox comboBox)
    {
        if (comboBox.SelectedIndex < 0) { return null; }
        object item = comboBox.Items[comboBox.SelectedIndex];
        return item.GetType().GetProperty("Key").GetValue(item, null);
    }
    // Get ComboBox.SelectedText
    private object ComboBoxSelectedText(ComboBox comboBox)
    {
        if (comboBox.SelectedIndex < 0) { return null; }
        object item = comboBox.Items[comboBox.SelectedIndex];
        return item.GetType().GetProperty("Value").GetValue(item, null);
    }

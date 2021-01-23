    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        var comboBox = sender as ComboBox;
        if (comboBox.SelectedItem != null)
        {
            string selectedItem = comboBox.SelectedItem.ToString();
            comboBox.Items = myDataSource.Where(x => x.StartsWith(selectedItem.Substring(0, 2))
                                                  && x.Length.Equals(selectedItem.Length));
        }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        comboBox2.Items.Clear();
        if (comboBox1.SelectedIndex > -1)
        {
            string brand = brandsAndModels.Keys.ElementAt(comboBox1.SelectedIndex);
            comboBox2.Items.AddRange(brandsAndModels[brand]);
        }
    }

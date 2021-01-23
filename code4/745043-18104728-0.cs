    private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        Person person = (Person)comboBox.SelectedItem;
        if (person == Person.Empty)
            MessageBox.Show("Default item selected!");
    }    

        List<object> coll = new List<Object>();
        List<Object> dbItems = new List<Object>();
        private void FillComboBox(object currSelected, ComboBox control)
        {
            control.Items.Clear();
            foreach (object c in dbItems)
            {
                if ((coll.Contains(c) == false) || (c == currSelected))
                {
                    control.Items.Add(c);
                }
            }
            control.SelectedItem = currSelected;
        }
        private void SelectedItemChanged()
        {
            foreach (object c in coll) {
                if ((comboBox1.SelectedItem != null && c.Equals(comboBox1.SelectedItem)) ||
                    (comboBox2.SelectedItem != null && c.Equals(comboBox2.SelectedItem)) ||
                    (comboBox3.SelectedItem != null && c.Equals(comboBox3.SelectedItem)))
                {
                }else{
                    coll.Remove(c);
                }
            }
        }
        
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            // That code must be in every combobox_selectedValueChanged
            SelectedItemChanged();
            FillComboBox(coll, comboBox1);
            FillComboBox(coll, comboBox2);
            FillComboBox(coll, comboBox3);
        }

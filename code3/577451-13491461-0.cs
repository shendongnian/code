    using(CheckBox checkbox = new CheckBox())
    {
        if (this.comboBox_Meta.SelectedItem != null)
        {
            if (this.comboBox_Meta.SelectedIndex != 1)
            {
                checkbox.Checked = true;
            }
            else
            {
               checkbox.Checked = false;
            }
            this.my_Helper.SetValueFromCheckBox("xxx", checkbox);
        }
    }

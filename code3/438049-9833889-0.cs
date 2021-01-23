    public Dictionary<string, string> Values
    {
        get
        {
            var values = new Dictionary<string, string>();
            foreach (var control in Controls)
            {
                switch(control.GetType().Name) 
                {
                    case "TextBox" : 
                        var textBox = (TextBox)control;
                        values.Add(textBox.Name, textBox.Text);
                        break;
                    case "ComboBox":
                        var comboBox = (ComboBox)control;
                        values.Add(comboBox.Name, comboBox.SelectedItem.ToString());
                        break;
                    case "CheckBox":
                        var checkBox = (CheckBox)control;
                        values.Add(checkBox.Name, checkBox.Checked.ToString());
                        break;
                }
            }
            return values;
        }
        set
        {
            foreach (var control in Controls)
            {
                switch (control.GetType().Name)
                {
                    case "TextBox":
                        var textBox = (TextBox)control;
                        textBox.Text = value[textBox.Name];
                        break;
                    case "ComboBox":
                        var comboBox = (ComboBox)control;
                        comboBox.SelectedItem = value[comboBox.Name];
                        break;
                    case "CheckBox":
                        var checkBox = (CheckBox)control;
                        checkBox.Checked = bool.Parse(value[checkBox.Name]);
                        break;
                }
            }
        }

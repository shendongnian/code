    //List<TextBox> listTextBoxes = new List<TextBox>();
    //populate the list of textboxes
    //List<double> listEaveLength = new List<double>();
    for (int i = 1; i <= comboBox1.SelectedIndex + 1; i++)
    {
        if (listTextBoxes[i].IsEnabled == false)
        {
            listEaveLength[i] = 0;
        }
        else if (listTextBoxes[i].Text == "")
        {
            throw new Exception(listTextBoxes[i].Name +  " must have a value");
        }
        else if (!double.TryParse(listTextBoxes[i].Text, out listEaveLength[i]))
        {
            throw new Exception(listTextBoxes[i].Name + " must be numerical");
        }
    }

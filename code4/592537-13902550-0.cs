    StringBuilder sb = new StringBuilder();
    var comboBoxes = FindControls<ComboBox>(panel1).ToList();
    var textBoxes = FindControls<TextBox>(panel1).ToList();
    
    foreach (var comboBox in comboBoxes)
        sb.AppendLine(comboBox.SelectedItem.ToString());
    
    foreach (var textbox in textBoxes)
        sb.AppendLine(textbox.Text);
    
    MessageBox.Show(sb.ToString());

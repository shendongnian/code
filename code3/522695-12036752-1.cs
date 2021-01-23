    if (radioButton1.Checked)
    {
        int a; string s = comboBox1.SelectedItem.ToString();
    
        if (string.Compare(s, "30 days", true) == 0) { a = 30; } 
        else if (string.Compare(s, "60 days", true) == 0) { a = 60; } 
        else 
        { 
            MessageBox.Show(comboBox1.SelectedItem.ToString()); 
        }
    }

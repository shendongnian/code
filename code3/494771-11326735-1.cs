    String strInput = textBox_ImportRowsList.Text;
    foreach (String s in strInput.Split(new[]{',', ' '}, StringSplitOptions.RemoveEmptyEntries))
    {
        if(!Regex.IsMatch(s, @"^\d+(,\d+)*$"))
        {
            errorProvider1.SetError(label_ListRowPosttext, "Row Count invalid!");    
        }
    }

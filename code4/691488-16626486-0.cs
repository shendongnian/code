    string selection = string.Empty;
    
    if (radAction.Checked)
    {
        selection = radAction.Text;
    }
    else if (radComedy.Checked)
    {
        selection = radComedy.Text;
    }
    else
        MessageBox.Show("Please Choose Movie Type");

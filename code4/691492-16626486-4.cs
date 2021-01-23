    string selection = string.Empty;
    try
    {
        if (radAction.Checked)
        {
            selection = radAction.Text;
        }
        else if (radComedy.Checked)
        {
            selection = radComedy.Text;
        }
    
        else
            throw new MovieSelectionNotFoundException("Please Choose Movie Type");
    
        MessageBox.Show(selection);
    }
    
    catch (MovieSelectionNotFoundException msg)
    {
        MessageBox.Show(msg.Message);
    }

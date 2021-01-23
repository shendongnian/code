    private void listview1_AfterLabelEdit(object sender, LabelEditEventArgs e)
    {
        try
        {
            const int maxPermittedLength = 1;
    
            if (e.Label.Length > maxPermittedLength)
            {
                //trim text
                listview1.Items[e.Item].SubItems[0].Text = listview1.Items[e.Item].SubItems[0].Text.Substring(0, maxPermittedLength); //or something similar
                //or
                //show a warning message
    
                //or
    
                e.CancelEdit = true; //cancel the edit
            }
        }
        catch (Exception ex)
        {
            
        }
    }

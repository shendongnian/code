    foreach (DictionaryEntry d in e.NewValues)
    {
        String oldValue = e.OldValues[d.Key] == null ? "" : e.OldValues[d.Key].ToString();
        String newValue = d.Value == null ? "" : d.Value.ToString();
        if (oldValue != newValue)
        {                    
            return; // -- change detected
        }
    }
    e.Cancel = true; // -- don't execute the update
    myGridView.EditIndex = -1;

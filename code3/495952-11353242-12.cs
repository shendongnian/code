    foreach(Control c in this.Controls)
    {
        if(c is CheckBox)
        {
            CheckBox cb = (CheckBox)c;
            if(cb.IsChecked)
            {
                string fieldName = cb.Attributes["fieldName"];
                string fieldValue = cb.Attributes["fieldValue"];
    
                someDictionaryMaybe.Add(string.Format("[{0}] = '{1}'", fieldName, fieldValue), fieldName);
            }
        }
    }
    // loop through the dictionary, joining the different expressions with ORs and ANDs
    // or use LINQ to put it all together, it's up to you.  The fieldName was added to 
    // the dictionary, which can be used to separate with ANDs and ORs.

    foreach (string item in lstModelUsers.Items)
    {
        if(!string.IsNullOrEmpty(item))
        { 
            Options.Default.ModelRemoveUsers.Add(item);              
        }
    }

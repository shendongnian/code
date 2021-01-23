    var itemsToAdd = lstModelUsers.Items.Where(item => !string.IsNullOrEmpty(item));
    foreach (string item in itemsToAdd)
    {
        Options.Default.ModelRemoveUsers.Add(item);   
    }

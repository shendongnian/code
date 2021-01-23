    var itemsToAdd = lstModelUsers.Items
        .Cast<string>()
        .Where(item => !string.IsNullOrEmpty(item));
    foreach (string item in itemsToAdd)
    {
        Options.Default.ModelRemoveUsers.Add(item);   
    }

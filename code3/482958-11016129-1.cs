    const string PR_STORE_ENTRYID = "http://schemas.microsoft.com/mapi/proptag/0x0FFB0102";
    Outlook.Table tasks = Application.Session.GetDefaultFolder(Outlook.OlDefaultFolders.olFolderTasks).GetTable();
    tasks.Columns.Add(PR_STORE_ENTRYID); // optimal for GetItemFromID
    while (!tasks.EndOfTable)
    {
        Outlook.Row task = tasks.GetNextRow();
        Outlook.TaskItem item = Application.Session.GetItemFromID(task["EntryID"], task.BinaryToString(PR_STORE_ENTRYID)) as Outlook.TaskItem;
    } 

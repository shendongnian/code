    // Add a command to edit the current Group
    contextMenu.Commands.Add(new UICommand("Edit this Group", async (contextMenuCmd) =>
    {
        Frame.Navigate(typeof(LocationGroupCreator), groupName);
    }));
    // Add a command to delete the current Group
    contextMenu.Commands.Add(new UICommand("Delete this Group", async (contextMenuCmd) =>
    {
        SQLiteUtils slu = new SQLiteUtils();
        slu.DeleteGroupAsync(groupName);
    }));

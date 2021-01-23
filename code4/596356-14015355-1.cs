    // Add a command to delete the current Group
    contextMenu.Commands.Add(new UICommand("Delete this Group", async (contextMenuCmd) =>
    {
        SQLiteUtils slu = new SQLiteUtils();
        await slu.DeleteGroupAsync(groupName);
    }));

    private void AssignDataContext(params TextBox[] textboxes)
    {
        foreach (var textbox in textboxes)
        {
            textbox.ContextMenu = new ContextMenu();
        }
    }

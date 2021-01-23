    var stackPanelItem = listBox.Items.OfType<FrameworkElement>()
                                .FirstOrDefault(x => x.Name == stackPanelName);
    if (stackPanelItem != null)
    {
        listBox.Items.Remove(stackPanelItem);
    }

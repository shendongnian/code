    List<Label> itemsToRemove = new List<Label>();
    foreach (Label label in Controls.OfType<Label>())
    {
        if (label.Tag != null && label.Tag.ToString() == "dispose")
        {
            itemsToRemove.Add(label);
        }
    }
    
    foreach (Label label in itemsToRemove)
    {
        Controls.Remove(label);
        label.Dispose();
    }

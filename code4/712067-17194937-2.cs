    List<Control> itemsToRemove = new List<Control>();
    foreach (Control ctrl in Controls.OfType<Label>())
    {
        if (ctrl.Tag != null && ctrl.Tag.ToString() == "dispose")
        {
            itemsToRemove.Add(ctrl);
        }
    }
    
    foreach (Control ctrl in itemsToRemove)
    {
        Controls.Remove(ctrl);
        ctrl.Dispose();
    }
   

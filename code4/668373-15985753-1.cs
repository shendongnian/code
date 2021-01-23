    List<Control> toRemove = salesBox.Controls.OfType<Control>().ToList();
    
    foreach(Control c in toRemove)
    {
     salesBox.Controls.Remove(c);
     c.Dispose();
    }

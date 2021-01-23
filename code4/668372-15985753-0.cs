    List<Control> toRemove = salesBox.Controls.ToList();
    
    foreach(Control c in toRemove)
    {
     salesBox.Controls.Remove(c);
     c.Dispose();
    }

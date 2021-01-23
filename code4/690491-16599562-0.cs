    List<Control> toBeRemoved = new List<Control>();
    foreach (Control c in this.Controls)
    {
        if (c instanceof TextBox)
        {
            toBeRemoved.Add(c);
        }
    }
    foreach (Control c in toBeRemoved)
    {
        this.Controls.Remove(c);
        c.Dispose();
    }

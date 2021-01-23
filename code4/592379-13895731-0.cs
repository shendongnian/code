    List<Control> toBeRemoved = panel1.Controls
        .Cast<Control>()
        .Where(c => c.Tag == sender)
        .ToList();
    foreach (Control c in toBeRemoved) {
        panel1.Controls.Remove(c);
    }

    List<ComboBox> combos = new List<ComboBox>();
    FindComboBoxes(this,combos);
    StringBuilder sb = new StringBuilder();
    foreach (var combo in combos)
    {
        sb.AppendLine(combo.Text);
    }
---
    void FindComboBoxes(Control parent,List<ComboBox> fillThis) 
    {
        foreach (Control c in parent.Controls)
        {
            if (c.GetType() == typeof(ComboBox)) fillThis.Add((ComboBox)c);
            FindComboBoxes(c, fillThis);
        }
    }

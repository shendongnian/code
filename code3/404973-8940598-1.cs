    Dictionary<string, object> assignedOnes = new Dictionary<string, object>();
    foreach(var key in keys)
      assignedOnes[key] = null;
    foreach (ListItem assignedEmployee in lstWorkers.Items)
      assignedEmployee.Selected = assignedOnes.ContainsKey(assignedEmployee.Text);

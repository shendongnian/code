    var constraintBackup = dataTable.Constraints.Cast<System.Data.Constraint>().ToList();
    dataTable.Constraints.Clear();
    dataTable.RejectChanges(); // This does not crash anymore
    foreach (System.Data.Constraint c in constraintBackup)
    {
        dataTable.Constraints.Add(c);
    }

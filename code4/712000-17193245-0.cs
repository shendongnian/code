    var toDelete = Controls.OfType<Label>()
                  .Where(c => c.Tag.ToString() != "non-disposal")
                  .ToList(); //need a list or array to avoid changing the collection as we remove from it
    foreach (var ctrl in toDelete)
    {
        Controls.Remove(ctrl);
        ctrl.Dispose();
    }
    //if this is part of a long method, also clear the list right away
    // so the garbage collector can see them
    toDelete.Clear(); 

    IEnumerable<EngineBase> bases = ...;
    // Get all the implementations which handle the grid.
    IEnumerable<EngineBase> handlesGrid = bases.
        Where(b => b.GetType().
            GetCustomAttributes(typeof(HandlesGridAttribute), true).Any());
    // Set the active property.
    foreach (EngineBase b in handlesGrid) b.Active = true;

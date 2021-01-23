    foreach (var o in objects)
    {
        if (string.IsNullOrEmpty(o.SubObject.Title))
        {
            o.SubObject.Title = ...;
        }
    }

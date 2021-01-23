    objects = objects.Select(o =>
    {
        if (string.IsNullOrEmpty(o.SubObject.Title))
        {
            o.SubObject.Title = ...;
        }
        return o;
    });

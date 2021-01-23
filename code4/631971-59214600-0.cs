    var context = new Context();
    foreach (var obj in list)
    {
        // do some stuff
        try
        {
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            // do some logging operation
            context.Dispose();
            context = new Context();
        }
    }
    context.Dispose();

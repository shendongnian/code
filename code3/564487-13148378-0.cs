    // get all your formatters
    var formatters = AppDomain.CurrentDomain.GetAssemblies()
        .SelectMany(s => s.GetTypes())
        .Where(p => Attribute.IsDefined(p, typeof(YourAttribute)));
    // Now go through each formatter and use the attribute to figure out which
    // output format it's for. Add these to some static IDictionary<OutputFormat, Type>
    
    

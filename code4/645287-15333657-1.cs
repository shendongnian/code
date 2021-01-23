     if (!ModelState.IsValid)
                {
    var errors = ModelState.SelectMany(x => x.Value.Errors.Select(z => z.Exception));
    
    // Breakpoint, Log or examine the list with Exceptions.
    
      }

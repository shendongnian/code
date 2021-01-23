    bool nameIsValid = (!string.IsNullOrEmpty(name));
    // If we are using a name it MUST be valid
    if (useName && !nameIsValid)
        throw new SomeException("..."); 
    // If we are NOT using a name, it is illegal to supply one
    if (!useName && nameIsValid)
        throw new SomeException("..."); 

    var properties = typeof(Person).GetProperties(BindingFlags.Public |
                                                      BindingFlags.Instance |
                                                      BindingFlags.DeclaredOnly);
    var parentProperties = typeof(PersonBase).GetProperties(BindingFlags.Public |
                                                      BindingFlags.Instance |
                                                      BindingFlags.DeclaredOnly);

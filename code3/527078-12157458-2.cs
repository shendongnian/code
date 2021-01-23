    GenericDatabaseDTO dto = /...*/;
    GenericDatabaseConstants.ActionType actionType = /...*/;
    Derived d = new Derived();
    Base b = d;
    // calls the non-generic version with special handling from Derived:
    d.ProcessDocument(dto, actionType);
    // calls the generic version from Base:
    b.ProcessDocument(dto, actionType);

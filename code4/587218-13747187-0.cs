    public void BaseType TTypeFactory.Create(/* parameters/objects needed to create Base Types*/)
    {
        // full of assumptions, modify to fit your needs:
        switch( typeID /*or some othervariable designating type to create*/)
        case 1: // DerivedType 1
            return new DerivedType1 { /* initialization parameters */ };
            break;
        case 2:
            return new DerivedType2 { /* initialization parameters */ };
            break;
        // etc.
        
    }

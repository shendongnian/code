    string newtype = null;
    int visibility = 0;
    if (item.Attribut == "Parent")
    {
        newtype = "Configurable";
        visibility = 4;
    }
    else if (item.Attribut == "Child")
    {
        newtype = "Simple";
        visibility = 1;
    }

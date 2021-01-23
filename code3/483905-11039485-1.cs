    ObjectContainer oc = new StringContainer();
    object o  = oc.Item;   // Valid, since ObjectContainer.Item is resolved
    string s1 = oc.Item;   // Not valid, since ObjectContainer.Item is still resolved
    string s2 = ((StringContainer)oc).Item;   
                           // Valid, since StringContainer.Item is now resolved

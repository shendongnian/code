    ObjectContainer oc = new QuotedStringContainer();
    object o  = oc.Item;   // Valid, since ObjectContainer.Item is resolved
    string s1 = oc.Item;   // Not valid, since ObjectContainer.Item is still resolved
    string s2 = ((StringContainer)oc).Item;   
                           // Valid, since QuotedStringContainer.Item is now resolved
                           // (polymorphism!)
    string s3 = ((QuotedStringContainer)oc).Item;   
                           // Valid, since QuotedStringContainer.Item is now resolved

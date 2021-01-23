    SearchResult result;
    
    result.Properties[customProp];     // might work for you
    result.Properties[customProp][0];  // works for me. see below
    
    using (DirectoryEntry entry = result.GetDirectoryEntry())
    {
    	entry.Properties[customProp]; // fails
    	entry.InvokeGet(customProp);  // fails as well for the weird data
    }

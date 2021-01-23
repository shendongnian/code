    // For this example let's say myContainer has 4 elements in it.
    for ( int i = myContainer.size() - 1; i >= 0; --i )
    {
        if ( someConditionIsMet )
        {
            myContainer.Remove(i);
        } 
    }
    1.) i = 3, someConditionIsMet is true, so we remove myContainer at index 3. myContainer.size() is now 3. 
    2.) i = 2, someConditionIsMet is false, so we do nothing.
    3.) i = 1, someConditionIsMet is true, so we remove myContainer at index 1. myContainer.size() is now 2. 
    4.) i = 0, someConditionIsMet is false, so we do nothing.

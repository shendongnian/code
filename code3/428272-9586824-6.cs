    for ( int i = 0; i < myContainer.size(); ++i )
    {
        if ( someConditionIsMet )
        {
            myContainer.Remove(i);
            --i;
        } 
    }
    1.) i = 0, someConditionIsMet is false, so we do nothing.
    2.) i = 1, someConditionIsMet is true, so we remove myContainer at index 1. myContainer.size() is now 3. We decrement i by 1, so it's now 0 again but will be 1 on the next iteration because of the ++i in the for loop.
    3.) i = 1, someConditionIsMet is false, so we do nothing.
    4.) i = 2, someConditionIsMet is true, so we remove myContainer at index 2. myContainer.size() is now 2. We decrement i by 1, so it's now 1 again but will be 2 on the next iteration because of the ++i in the for loop so we will not loop again because 2 is not less than myContainer.size(), which is now 2.

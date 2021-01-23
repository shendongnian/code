    for (int i=0; i < bytes.Length; i++)
    {
        sum += BitCountLookupArray [bytes [i]];
        if(sum >= 3)
        {
             return false   // This will stop the execution of unnecessary lines  
                            // as we need to know whether sum is less than 3 or not.                         
        }
    }
    return true;

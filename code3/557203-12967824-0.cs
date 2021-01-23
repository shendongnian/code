    if (someCondition && someOtherCondition && yetAnotherCondition)  
        setTime(theTime); // just one call, in one place, gets executed once
    
    switch(someValue) 
    {
        case "state 34": {
            //SetTime(theTime); // no longer necessary
            // other things
            if (TheTimeisRight(time)) // runs every call
            {
                //SetTime(theTime); // no longer necessary
                if (TheTimeisRight(time)) 
                { /*  some methods  */ }
            }
            break;
    
        ...etc...
    }

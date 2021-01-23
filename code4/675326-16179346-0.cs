    var initialList;//whatever this contains...
    List<List<Object>> retList = new List<List<Object>>();
    Type storedType = null;
    foreach(Object thing in initialList)
    {//we treat this like a simple array of objects, because we DONT know what's in it.
        if(storedType != null)
        {
            if(storedType.Equals(thing.GetType())
                instanceList.Add(thing);
            else
            {//add instanceList to the master return, then re-set stored type and the 
             //list and add the current thing to the new list
                retList.Add(instanceList);
                storedType = thing.GetType();
                instanceList = new List<Object>();
                instanceList.Add(thing);
            }
        }
        else
        {//should be First run only
            storedType = thing.GetType();
            instanceList.Add(thing);
        }
    }
    return retList;

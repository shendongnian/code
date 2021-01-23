    var results = new List<Filter_IDs>();
    var ids = new List<int>();
    var first = true;
    int thisType;
    foreach (var fl in ef.filterLines
                           .OrderBy(fl => fl.objectType)
                           .ThenBy(fl => fl.object_Id))
    {
        if (first)
        {
            thisType = fl.objectType;
            first = false;
        }
        else
        {
            if (fl.objectType == thisType)
            {
                ids.Add(fl.object_Id);
            }
            else
            {
               results.Add(new Filter_IDs
                    {
                        Type = thisType,
                        objects = ids
                    });
               thisType = fl.objectType;
               ids = new List<int>();   
            }
        }    
    }

    // Based on this spec: "CPUDataIWant is a List<List<dynamic>>"
    // and on the example, which states that the contents are numbers.
    //
    List<List<dynamic>> filteredList = new List<List<dynamic>>();
    foreach (List<dynamic> innerList in CPUDataIWant)
    {
        List<dynamic> innerFiltered = new List<dynamic>();
        // if elements are not in multiples of 3, the last one or two won't be checked.
        for (int i = 0; i < innerList.Count; i += 3)
        {   
            if(innerList[i+1] > innerList[i])
                if(innerList[i+2] > innerList[i+1])
                    innerFiltered.Add(innerList[i+2]);
                else
                    innerFiltered.Add(innerList[i+1]);
            else
                innerFiltered.Add(innerList[i]);
        }
        filteredList.Add(innerFiltered);
    }

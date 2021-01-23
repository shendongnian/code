    var myList = new List<MyObject>()    {
        new MyObject { ID = 1, Mukey = "1709649", FieldID = 191, Type = "Minor", PercentOfField = 18, Acres = 12.5181 },
        new MyObject { ID = 2, Mukey = "1709641", FieldID = 191, Type = "Minor", PercentOfField = 1, Acres = 0.49621 },
        new MyObject { ID = 3, Mukey = "1709620", FieldID = 191, Type = "Minor, Critical", PercentOfField = 72, Acres = 49.4322 },
        new MyObject { ID = 4, Mukey = "1709622", FieldID = 191, Type = "Minor", PercentOfField = 9, Acres = 5.89865 }
    };
    int offset = 0;
    for (int i = 0; i + offset < myList.Count; i++)
    {
        //check if the type is comma delimited
        if (myList[i].Type.Contains(","))
        {
            //get the separate types
            string[] types = myList[i].Type.Split(',');
            
            //for each type, add a new entry in the list
            foreach (string theType in types)
            {
                myList.Insert(
                    i + 1,
                    new MyObject
                    {
                        ID = myList[i].ID,
                        Mukey = myList[i].Mukey,
                        FieldID = myList[i].FieldID,
                        Type = theType.Trim(),
                        PercentOfField = myList[i].PercentOfField,
                        Acres = myList[i].Acres
                    }
                );
                //add to the offset to adjust the count in the loop
                // (we want to skip the new items)
                offset++;
            }
            //remove the old entry
            myList.RemoveAt(i);
        }
    }

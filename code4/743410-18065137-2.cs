    var listA = new List<string>()
                            {
                                "ASCB",
                                "test1", 
                                "test2",
                                "test3",
                                "test4",
                                "Arinc",
                                "testA",
                                "testB"
                            };
    var listB = new List<string>()
                            {
                                "ASCB",
                                "test1", 
                                "test5",
                                "test3",
                                "test6",
                                "Arinc",
                                "testC",
                                "testB"
                            };
    var dontRemoveThese = new List<string>(){"ASCB", "Arinc"};
    var listToRemove = new List<string>();
    foreach (var str in listA)
        if (listB.Contains(str))
            listToRemove.Add(str);
    foreach (var str in listToRemove){
        if (dontRemoveThese.contains(str))
            continue;
        listA.Remove(str);
        listB.Remove(str);
    }

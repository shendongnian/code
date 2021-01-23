    List<int> checkList = new List<int>();
    int[] firstList = new int[list1.Count];
    int[] scndList = new int[list2.Count];
    // Structure data
    for (var i = 0; i < firstList.Length; i++)
    {
        firstList[list1.Fvalue] = list1.intValue;
        scndList[list2.Fvalue] = list2.intValue;
        // Fvalue is that f, you can use substring and int parsing for that.
    }
    for (var i = 0; i < list1.Count; i++)
    {
        if (firstList[index] != scndList[index])
        {
            checkList.Add(firstList[index]);
        }
    }
    // checkList will be your answer.

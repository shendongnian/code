    List<int> numberList = new List<int>() { 30, 60, 120, 150, 270, 300, 330 };  
    Dictionary<int, int> result = new Dictionary<int, int>();
    int lastStart = numberList.First();
    for(int i=1; i < numberList.Count; i++)
    {
        if(numberList[i] >= lastStart + 30)
        {
            result.Add(lastStart, numberList[i]);
            if (i == numberList.Count - 1) break;
            lastStart = numberList[i + 1];
            i++;
        }
    }
    foreach (var item in result)
    {
        Console.WriteLine("{{{0}, {1}}}", item.Key, item.Value);
    }

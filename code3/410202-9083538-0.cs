    foreach (var list in CalculateQueueOrder(new List<string>() { "a", "b", "c", "d", "e" }))
    {
          Console.WriteLine(String.Join(" ",list));
    }
    IEnumerable<List<string>> CalculateQueueOrder(List<string> list)
    {
        //yield return list; //if you need the original list
        for (int i = 0; i < list.Count-1; i++)
        {
            var newList = new List<string>(list.Skip(1));
            newList.Add(list.First());
            list  = newList;
            yield return newList;
        }
    }

    var list1 = new List<string>() {"A", "B", "C", "D", "E", "F", "G"};
    var list2 = new List<string>() { "A", "B", "E","G" };
    var list3 = new List<string>();
    int j = 0;
    for(int i=0; i < list1.Count; i++)
    {
        var item = list1[i];
        if (item == list2[j])
        {
         list3.Add(item);
         j++;
        }
        else
        {
          list3.Add(null);
        }
     }

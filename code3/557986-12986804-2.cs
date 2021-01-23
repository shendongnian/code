    public static void SetHeights(this IEnumerable<MyClass> source, int value)
    {
        foreach (var item in source)
        {
           if (item.Name == "height")
           {
               item.Value = value;
           }
            
           yield return item;
        } 
    }
    var result = list.SetHeights(30).ToList();

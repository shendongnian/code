    var lst = new List<string[]>();
    lst.Add(new string[] { "ABC", "DEF" });
    lst.Add(new string[] { "GHI", "JKL" });
    
    foreach (var item in lst)
    {
    	Console.WriteLine(item.Length);
    }
    
    for (int i = 0; i < lst.Count; ++i)
    {
    	var array = lst[i];
    	Array.Resize(ref array, array.Length + 1);
    	array[array.Length - 1] = "EndOfBlock";
    	lst[i] = array;
    }
    
    foreach (var item in lst)
    {
    	Console.WriteLine(item.Length);
    }

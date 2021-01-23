    var myList = new List<object>();
    
    for (var i = 0; i < 9; i++)
    {
        myList.Add(new object());
    }
    
    for (var i = 0; i < myList.Count; i++)
    {
        myList[i] = null;
    }

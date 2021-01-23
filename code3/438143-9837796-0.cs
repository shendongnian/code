    var a = new List<string>{"A","B","C","D","E"};
    var b = new List<string>{"A","C","B","D","D1"};
    
    var removed = a.Except(b);
    var moved = a.Where(x => b[a.IndexOf(x)] != x && !removed.Contains(x));
    List<string> newlyInserted = new List<string>();
    foreach (var item in removed)
    {
        //Newly inserted into the list - D1
    	newlyInserted.Add(b[a.IndexOf(item)]);
        //Index of D1 if required
        var indexOfNewlyAddedItem = a.IndexOf(item);
    }

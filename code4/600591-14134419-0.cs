    int[] ids = { 1, 2, 3, 4 };
    var id = ids.Select(s => s);
    var list = attributeIDs.Cast<int>().ToList();
    //or try 
    //List<int> list = new List<int>(arrayList.ToArray(typeof(int)));
    var sam = list.Where(s => id.Contains(s));
    //if you want to remove items than , !Contains() rather an Contains()
    // var sam = list.Where(s => !id.Contains(s); 
    ArrayList myArrayList = new ArrayList(sam );

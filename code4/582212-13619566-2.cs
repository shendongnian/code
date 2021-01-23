    var list = new List<string>() { "Foo", "Bar", "Spam" };
    // TKey is int, TValue is string
    int i = 0;
    Dictionary<int,string> dict1 = list.ToDictionary( _ => i++ );          
 
    // TKey is string, TValue is int
    i = 0;
    Dictionary<string,int> dict2 = list.ToDictionary( x => x, _ => i++ );

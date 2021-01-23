    //Create an instance of InfiniteList where T is List<string>
    InfiniteList<List<string>> list = new InfiniteList<List<string>>();
    
    //Add a new instance of InfiniteList<List<string>> to "list" instance.
    list.Add(new InfiniteList<List<string>>());
    
    //access the first element of "list". Access the Value property, and add a new string to it.
    list[0].Value.Add("Hello World");

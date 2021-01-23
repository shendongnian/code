    var collection = new SynchronizedCollection<string>();
    collection.Add("Test1");
    collection.Add("Test2");
    collection.Add("Test3");
    collection.Add("Test4");
    var enumerator = collection.GetEnumerator();
    enumerator.MoveNext();
    collection.Add("Test5");
    //The next call will throw a InvalidOperationException ("Collection was modified")
    enumerator.MoveNext();

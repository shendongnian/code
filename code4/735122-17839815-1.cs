    List<string> mylist = new List<string>();
    mylist.Add("Test1");
    mylist.Add("Test2");
    mylist.Add("Test3");
    
    string lastItem = mylist[mylist.Count - 1];
    foreach(string s in mylist)
    {
        if (s != lastItem)
        Console.Write(s + ", ");
        else
        Console.Write(s);
    }

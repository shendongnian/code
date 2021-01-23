    List<ICommonInterface> lst = new List<ICommonInterface>();
    lst.Add(new Class1());
    lst.Add(new NumberWrapper(77));
    lst.Add(new TextWrapper("hello"));
    Console.WriteLine(lst[0].Text);

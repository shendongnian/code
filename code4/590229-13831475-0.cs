    var tasks = new List<Task>();
    if (!string.IsNullOrEmpty(link1))
    {
        string[] link1_ar = link1.Split(sep, StringSplitOptions.None);
        string page1 = link1_ar[1];
        string filter1 = link1_ar[2];
        string code2 = link2_ar[3];
        var link1task = Task.Run(MyMethod(summary, page1, filter1, code1));
        tasks.Add(link1task);
    }
    if (!string.IsNullOrEmpty(link2))
    {
        string[] link2_ar = link2.Split(sep, StringSplitOptions.None);
        string page2 = link2_ar[1];
        string filter2 = link2_ar[2];
        string code2 = link2_ar[3];
        var link2task = Task.Run(MyMethod(summary, page2, filter2, code2));
        tasks.Add(link2task);
    }
    if (!string.IsNullOrEmpty(link3))
    {
        string[] link3_ar = link3.Split(sep, StringSplitOptions.None);
        string page3 = link3_ar[1];
        string filter3 = link3_ar[2];
        string code3 = link3_ar[3];
        var link3task = Task.Run(MyMethod(summary, page3, filter3, code3));
        tasks.Add(link3task);
    }
    Task.WaitAll(tasks.ToArray());

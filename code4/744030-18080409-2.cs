    for (int i = 0; i < foo.Count; i++)
    {
        string element = foo[i];
        if (element.Length > 5)
        {
            newFoo.Add(element);
        }
    }

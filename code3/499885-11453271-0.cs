    public event Action<string> a;
    
    public void AddToDelegate()
    {
        for (int i = 0; i < DelegateList.Length; i++)
        {
            int capture = i;
            a += () => SomeFunc(capture.ToString());
        }
    }
    
    public string GetData()
    {
        StringBuilder _sb = new StringBuilder();
        if (a != null)
        {
            Delegate[] DelegateList = a.GetInvocationList();
            for (int i = 0; i < DelegateList.Length; i++)
            {
                _sb.Append(((A)DelegateList[i]));
            }
        }
        return _sb.ToString();
    }

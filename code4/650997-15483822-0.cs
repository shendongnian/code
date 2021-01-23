    List<string> mList = new List<string>();
    
    for (int i = 0; i < _CAUSE.Length; i = i + 2)
    {
        mList.Add(_CAUSE.Substring(i, 2));
    }
    
    return mList;

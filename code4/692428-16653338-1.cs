    var enumerable = Enumerable.Range(1, 100);
    IEnumerator<int> enumerator = enumerable.GetEnumerator();
    try
    {
        while (enumerator.MoveNext())
        {
            int element = enumerator.Current;
            //here goes your action instructions
        }
    }
    finally
    {
        IDisposable disposable = enumerator as System.IDisposable;
        if (disposable != null) disposable.Dispose();
    }

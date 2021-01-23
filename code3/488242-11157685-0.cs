    public System.Collections.IEnumerator GetEnumerator()
    {
        foreach (object obj in underLyingCollection)
        {
            yield return obj;
        }
    }

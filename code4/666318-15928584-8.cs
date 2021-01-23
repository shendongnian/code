    protected virtual void ReadResources()
    {
      IDictionaryEnumerator enumerator = this.Reader.GetEnumerator();
      while (enumerator.MoveNext())
      {
        object obj = enumerator.Value;
        this.Table.Add(enumerator.Key, obj);
      }
    }

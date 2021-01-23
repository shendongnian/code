    public IEnumerator<int> GetEnumerator(string whatever)
    {
      // Perform validation immediately when called
      if (whatever == null) throw new ArgumentException();
      return GetEnumeratorInternal(whatever);
    }
    private IEnumerator<int> GetEnumeratorInternal(string whatever)
    {
      // Everything in this method happens on first MoveNext
      yield return 1;
      yield return 2;
    }

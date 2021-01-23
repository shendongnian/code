    IEnumerator DoSomething()
    {
      /* ... */
    }
     
    IEnumerator DoSomethingUnlessInterrupted()
    {
      IEnumerator e = DoSomething();
      bool interrupted = false;
      while(!interrupted)
      {
        e.MoveNext();
        yield return e.Current;
        interrupted = HasBeenInterrupted();
      }
    }

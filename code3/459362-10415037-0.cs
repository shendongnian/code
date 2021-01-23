    E enumerator = (collection).GetEnumerator(); // non-generic interface
    try {
       while (enumerator.MoveNext()) { // enumerator also non-generic
          ElementType element = (ElementType)enumerator.Current;
          statement;
       }
    }
    finally {
       IDisposable disposable = enumerator as System.IDisposable;
       if (disposable != null) disposable.Dispose();
    }

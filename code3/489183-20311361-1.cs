        class Test : IEnumerable
        {
            IEnumerator IEnumerable.GetEnumerator()
            {
            }
        }
    This is because in this case `foreach` is implemented as (provided there is no other public `GetEnumerator` method in the class):
        IEnumerator enumerator = ((IEnumerable)(collection)).GetEnumerator();
        try {
            ElementType element; //pre C# 5
            while (enumerator.MoveNext()) {
                ElementType element; //post C# 5
                element = (ElementType)enumerator.Current;
                statement;
           }
        }
        finally {
            IDisposable disposable = enumerator as System.IDisposable;
            if (disposable != null) disposable.Dispose();
        }

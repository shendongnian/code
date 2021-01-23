        class Test
        {
            public SomethingEnumerator GetEnumerator()
            {
            }
        }
        class SomethingEnumerator
        {
            public Something Current //could return anything
            {
                get { return ... }
            }
            public bool MoveNext()
            {
            }
        }
        //now you can call
        foreach (Something thing in new Test()) //type safe
        {
        }
    This is then translated by the compiler to:
        E enumerator = (collection).GetEnumerator();
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

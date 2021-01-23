        IEnumerator<T> enumerator = ((IEnumerable<T>)(collection)).GetEnumerator();
        try {
            ElementType element; //pre C# 5
            while (enumerator.MoveNext()) {
                ElementType element; //post C# 5
                element = (ElementType)enumerator.Current; //Current is `T` which is cast
                statement;
           }
        }
        finally {
            enumerator.Dispose();
        }

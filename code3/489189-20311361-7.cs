        IEnumerator<ElementType> enumerator = ((IEnumerable<ElementType>)(collection)).GetEnumerator();
        try {
            ElementType element; //pre C# 5
            while (enumerator.MoveNext()) {
                ElementType element; //post C# 5
                element = (ElementType)enumerator.Current;
                statement;
           }
        }
        finally {
            enumerator.Dispose();
        }

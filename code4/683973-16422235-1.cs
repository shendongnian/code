    {
        E e = ((C)(x)).GetEnumerator();
        try {
            V v;
            while (e.MoveNext()) {
                v = (V)(T)e.Current; // <-- note the explicit cast to V
                embedded-statement
            }
        }
        finally {
            … // Dispose e
        }
    }

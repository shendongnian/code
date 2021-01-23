    var enumerator = y.GetEnumerator();
    try {
        object x; // See footnote 1
        while (enumerator.MoveNext()) {
            x = enumerator.Current;
            Console.WriteLine(x);
        }
    } finally {
        ((IDisposable)enumerator).Dispose();
    }

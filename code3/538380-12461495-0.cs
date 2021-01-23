    public static IEnumerable<Exception> AsEnumerable(this Exception self)
    {
        for (var e = self; e != null; e = e.InnerException) yield return e;
    }
    
    foreach (var e in myException.AsEnumerable()) { /* print debug info */ }
    // or
    var exceptionString = string.Join("", myException.AsEnumerable().Select(e =>
        /* debug info */
    ));

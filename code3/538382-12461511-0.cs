    public static IEnumerable<string> FormatExceptionHtml(Exception instance)
    {
        if (instance != null)
            yield return instance.Message + "<br />";
        if (instance.InnerException != null)
            foreach (var inner in FormatExceptionHtml(instance.InnerException))
            {
                yield return inner;
            }
    }

    // supports int, float, DateTime, etc.
    MvcHtmlString MyMethod(this HtmlHelper html, string title, IEnumerable<int> value)
    MvcHtmlString MyMethod(this HtmlHelper html, string title, IEnumerable<float> value)
    MvcHtmlString MyMethod(this HtmlHelper html, string title, IEnumerable<DateTime> value)
    // supports implementations of MyInterface
    MvcHtmlString MyMethod(this HtmlHelper html, string title, IEnumerable<IMyInterface> value)

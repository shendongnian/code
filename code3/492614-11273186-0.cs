    public static mvchtmlstring Foo(string taglabel, string url, RouteValueDictionary values)
    {
    
    
                TagBuilder tb = new TagBuilder("a");
    tb.Attrubutes.add("href",url);
    tb.setInnerText(taglabel);
                tb.MergeAttributes(values);
    return new MvcHtmlString(tb.toString());
    }

    /// <param name="linkText">Text for Link</param>
    /// <param name="containerElement">where this block will be inserted in the HTML using a jQuery append method</param>
    /// <param name="counterElement">name of the class inserting, used for counting the number of items on the form</param>
    /// <param name="collectionProperty">the prefix that needs to be added to the generated HTML elements</param>
    /// <param name="nestedType">The type of the class you're inserting</param>
    public static IHtmlString LinkToAddNestedForm<TModel>(this HtmlHelper<TModel> htmlHelper, string linkText,
        string containerElement, string counterElement, string collectionProperty, Type nestedType)
    {
        var ticks = DateTime.UtcNow.Ticks;
        var nestedObject = Activator.CreateInstance(nestedType);
        var partial = htmlHelper.EditorFor(x => nestedObject).ToHtmlString().JsEncode();
    
        partial = partial.Replace("id=\\\"nestedObject", "id=\\\"" + collectionProperty + "_" + ticks + "_");
        partial = partial.Replace("name=\\\"nestedObject", "name=\\\"" + collectionProperty + "[" + ticks + "]");
    
        var js = string.Format("javascript:addNestedForm('{0}','{1}','{2}','{3}');return false;", containerElement,
            counterElement, ticks, partial);
    
        TagBuilder tb = new TagBuilder("a");
        tb.Attributes.Add("href", "#");
        tb.Attributes.Add("onclick", js);
        tb.InnerHtml = linkText;
    
        var tag = tb.ToString(TagRenderMode.Normal);
        return MvcHtmlString.Create(tag);
    }
    private static string JsEncode(this string s)
    {
        if (string.IsNullOrEmpty(s)) return "";
        int i;
        int len = s.Length;
    
        StringBuilder sb = new StringBuilder(len + 4);
        string t;
    
        for (i = 0; i < len; i += 1)
        {
            char c = s[i];
            switch (c)
            {
                case '>':
                case '"':
                case '\\':
                    sb.Append('\\');
                    sb.Append(c);
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                case '\n':
                    //sb.Append("\\n");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\r':
                    //sb.Append("\\r");
                    break;
                default:
                    if (c < ' ')
                    {
                        //t = "000" + Integer.toHexString(c); 
                        string tmp = new string(c, 1);
                        t = "000" + int.Parse(tmp, System.Globalization.NumberStyles.HexNumber);
                        sb.Append("\\u" + t.Substring(t.Length - 4));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        return sb.ToString();
    }

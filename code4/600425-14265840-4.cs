    public static IHtmlString Content(this HtmlHelper @this, Func<object, HelperResult> razor)
    {
        using (MemoryStream ms = new MemoryStream())
        using (TextWriter tw = new StreamWriter(ms))
        {
            Delegate @delegate = (Delegate)razor;
            WebViewPage target = (WebViewPage)@delegate.Target;
            TextWriter tmp = target.Html.ViewContext.Writer;
            try
            {
                target.Html.ViewContext.Writer = tw;
                razor(null).WriteTo(tw);
                tw.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                TextReader tr = new StreamReader(ms);
                    
                return MvcHtmlString.Create(tr.ReadToEnd());
            }
            finally
            {
                target.Html.ViewContext.Writer = tmp;
            }
        }
    }

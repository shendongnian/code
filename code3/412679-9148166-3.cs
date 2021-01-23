    class Program
    {
      static string html = "<html><meta name=\"keywords\" content=\"HTML, CSS, XML\" /></html>";
      static void Main(string[] args)
      {
        HtmlDocument doc = new HtmlDocument();
        doc.LoadHtml(html);
        XPathNavigator nav = doc.CreateNavigator();
        // Create the custom context and add the namespace to the context
        XsltCustomContext ctx = new XsltCustomContext(new NameTable());
        ctx.AddNamespace("Extensions", XsltCustomContext.NamespaceUri);
        // Build the XPath query using the new function
        XPathExpression xpath = 
          XPathExpression.Compile("//meta[@name[Extensions:CaseInsensitiveComparison('Keywords')]]");
        // Set the context for the XPath expression to the custom context containing the 
        // extensions
        xpath.SetContext(ctx);
        var element = nav.SelectSingleNode(xpath);
        // Now we have the element
      }
    }

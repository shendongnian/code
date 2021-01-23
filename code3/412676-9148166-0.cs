    public class XsltCustomContext : XsltContext
    {
      public const string NamespaceUri = "http://XsltCustomContext";
    
      public XsltCustomContext()
      {
      }
      public XsltCustomContext(NameTable nt) 
        : base(nt)
      {    
      }
      public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
      {
        // Check that the function prefix is for the correct namespace
        if (this.LookupNamespace(prefix) == NamespaceUri)
        {
          // Lookup the function and return the appropriate IXsltContextFunction implementation
          switch (name)
          {
            case "CaseInsensitiveComparison":
              return CaseInsensitiveComparison.Instance;
          }
        }
        return null;
      }
      public override IXsltContextVariable ResolveVariable(string prefix, string name)
      {
        return null;
      }
      public override int CompareDocument(string baseUri, string nextbaseUri)
      {
        return 0;
      }
      public override bool PreserveWhitespace(XPathNavigator node)
      {
        return false;
      }
      public override bool Whitespace
      {
        get { return true; }
      }
      // Class implementing the XSLT Function for Case Insensitive Comparison
      class CaseInsensitiveComparison : IXsltContextFunction
      {
        private static XPathResultType[] _argTypes = new XPathResultType[] { XPathResultType.String };
        private static CaseInsensitiveComparison _instance = new CaseInsensitiveComparison();
      
        public static CaseInsensitiveComparison Instance
        {
          get { return _instance; }
        }      
        #region IXsltContextFunction Members
      
        public XPathResultType[] ArgTypes
        {
          get { return _argTypes; }
        }
        public int Maxargs
        {
          get { return 1; }
        }
        public int Minargs
        {
          get { return 1; }
        }
        public XPathResultType ReturnType
        {
          get { return XPathResultType.Boolean; }
        }
        public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator navigator)
        {                
          // Perform the function of comparing the current element to the string argument
          // NOTE: You should add some error checking here.
          string text = args[0] as string;
          return navigator.Value.Equals(text, StringComparison.InvariantCultureIgnoreCase);        
        }
        #endregion
      }
    }

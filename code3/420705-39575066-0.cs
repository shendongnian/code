    public class HtmlDocumentFactory
    {
      private static Type htmlDocType = typeof(System.Windows.Forms.HtmlDocument);
      private static Type htmlShimManagerType = null;
      private static object htmlShimSingleton = null;
      private static ConstructorInfo docCtor = null;
      
      public static HtmlDocument Create()
      {
        if (htmlShimManagerType == null)
        {
          // get a type reference to HtmlShimManager
          htmlShimManagerType = htmlDocType.Assembly.GetType(
            "System.Windows.Forms.HtmlShimManager"
            );
          // locate the necessary private constructor for HtmlShimManager
          var shimCtor = htmlShimManagerType.GetConstructor(
            BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null
            );
          // create a new HtmlShimManager object and keep it for the rest of the
          // assembly instance
          htmlShimSingleton = shimCtor.Invoke(null);
        }
        
        if (docCtor == null)
        {
          // get the only constructor for HtmlDocument (which is marked as private)
          docCtor = htmlDocType.GetConstructors(
            BindingFlags.NonPublic | BindingFlags.Instance
            )[0];
        }
        
        // create an instance of mshtml.HTMLDocument2 (in the form of 
        // IHTMLDocument2 using HTMLDocument2's class ID)
        object htmlDoc2Inst = Activator.CreateInstance(Type.GetTypeFromCLSID(
          new Guid("25336920-03F9-11CF-8FD0-00AA00686F13")
          ));
        var argValues = new object[] { htmlShimSingleton, htmlDoc2Inst };
        // create a new HtmlDocument without involving WebBrowser
        return (HtmlDocument)docCtor.Invoke(argValues);
      }
    }

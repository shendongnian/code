    [ComVisible(true),
     Guid("DA8EA345-02AE-434E-82E9-448E3DB7629E"),
     ClassInterface(ClassInterfaceType.None), ProgId("MyExtension"),
     ComDefaultInterface(typeof(IExtension))]
    public class BrowserHelperObject : IObjectWithSite, IExtension
    {
        ...
        public int Foo(string s) { ... }
        ...
        public void OnDocumentComplete(dynamic frame, ref dynamic url)
        {
            ...
            dynamic window = browser.Document.parentWindow;
            IExpando windowEx = (IExpando)window;
            windowEx.AddProperty("myExtension");
            window.myExtension = this;
            ...
        }
        ...
    }

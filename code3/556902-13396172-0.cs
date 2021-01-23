    public partial class frmBrowser : Form, IRequestHandler
    {
        private readonly WebView web_view;
        public frmBrowser()
        {
            InitializeComponent();
            web_view = new WebView("http://stackoverflow.com", new BrowserSettings());
            web_view.Dock = DockStyle.Fill; 
            web_view.RequestHandler = this;
            tsContainer.ContentPanel.Controls.Add(web_view);
        }
        #region IRequestHandler Members
        bool IRequestHandler.OnBeforeBrowse(IWebBrowser browser, IRequest request,
                                   NavigationType naigationvType, bool isRedirect)
        {
            System.Diagnostics.Debug.WriteLine("OnBeforeBrowse");
            return false;
        }
        bool IRequestHandler.OnBeforeResourceLoad(IWebBrowser browser,
                                         IRequestResponse requestResponse)
        {
            System.Diagnostics.Debug.WriteLine("OnBeforeResourceLoad");
            IRequest request = requestResponse.Request;
            if (request.Url.EndsWith("header.png"))
            {
                MemoryStream stream = new System.IO.MemoryStream();
                FileStream file = new FileStream(@"C:\tmp\header.png", FileMode.Open, FileAccess.Read, FileShare.Read);
                byte[] bytes = new byte[file.Length];
                file.Read(bytes, 0, (int)file.Length);
                stream.Write(bytes, 0, (int)file.Length);
                file.Close();
                requestResponse.RespondWith(stream, "image/png");
            }
            return false;
        }
        void IRequestHandler.OnResourceResponse(IWebBrowser browser, string url,
                                       int status, string statusText,
                                       string mimeType, WebHeaderCollection headers)
        {
            System.Diagnostics.Debug.WriteLine("OnResourceResponse");
        }
        #endregion
    }

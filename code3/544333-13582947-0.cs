        public CustomFileUpload FileUpload
        {
            get
            {
                return new CustomFileUpload(WebBrowser.Current.hWnd, "_Layout");
                //return Document.FileUpload(Find.ByName("file"));
            }
        }

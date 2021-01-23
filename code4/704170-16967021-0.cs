    public sealed class GlobalData
    {
        public static GlobalData Current
        {
            get
            {
                // soft cast using "as" which will return null if the type is not correct
                var globalData = WebPageContext.Current.PageData["GlobalData"] as GlobalData;
                if (globalData == null)
                {
                    // Need to instantiate
                    globalData = new GlobalData();
                    WebPageContext.Current.PageData["GlobalData"] = globalData;
                }
                return globalData;
            }
        }
        public string SomeData { get; set; }
    }
